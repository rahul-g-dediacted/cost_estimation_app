#region Header
// Revit API .NET Labs
//
// Copyright (C) 2007-2019 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software
// for any purpose and without fee is hereby granted, provided
// that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
#endregion // Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.DB.Architecture;
using DesignAutomationFramework;
using Newtonsoft.Json;

#endregion // Namespaces

namespace ExportImageCastingReport
{
   [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
   [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
   public class HandleExportImage : IExternalDBApplication
   {
      private ControlledApplication _app;
      public ExternalDBApplicationResult OnStartup(ControlledApplication app)
      {
         _app = app;
         DesignAutomationBridge.DesignAutomationReadyEvent += HandleDesignAutomationReadyEvent;
         return ExternalDBApplicationResult.Succeeded;
      }

      public ExternalDBApplicationResult OnShutdown(ControlledApplication app)
      {
         return ExternalDBApplicationResult.Succeeded;
      }

      public void HandleDesignAutomationReadyEvent(object sender, DesignAutomationReadyEventArgs e)
      {

         var data = e.DesignAutomationData;
         if (data == null) throw new ArgumentNullException(nameof(data));

         Application rvtApp = data.RevitApp;
         if (rvtApp == null) throw new InvalidDataException(nameof(rvtApp));

         //string modelPath = data.FilePath;
         //if (String.IsNullOrWhiteSpace(modelPath)) throw new InvalidDataException(nameof(modelPath));

         //Document doc = data.RevitDoc;
         //LogTrace("74 " + doc?.PathName);
         //if (doc == null) throw new InvalidOperationException("Could not open document.");

         ModelPath path = ModelPathUtils.ConvertUserVisiblePathToModelPath("revit.rvt");
         var opts = new OpenOptions
         {
            DetachFromCentralOption = DetachFromCentralOption.DetachAndDiscardWorksets
         };

         var doc = data.RevitApp.OpenDocumentFile(path, opts);

         List<ElementId> elementIds = new List<ElementId>();


         var levels = new FilteredElementCollector(doc).OfClass(typeof(Level)).Cast<Level>().ToList();
         foreach (var level in levels)
         {
            var ids = GetOutermostWalls(doc, level);
            elementIds.AddRange(ids);
         }

         var allWalls = new FilteredElementCollector(doc).OfClass(typeof(Wall)).Cast<Wall>()
            .Where(x => x.WallType.Kind == WallKind.Basic).ToList();
         var interiors = allWalls.Where(x => elementIds.All(id => id != x.Id)).Select(x => new DataWall(x)).ToList();
         var exteriors = allWalls.Where(x => elementIds.Any(id => id == x.Id)).Select(x => new DataWall(x)).ToList();

         var doorsWindows = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
            .Where(x => x.Category != null && (x.Category.ToBuiltinCategory() == BuiltInCategory.OST_Doors || x.Category.ToBuiltinCategory() == BuiltInCategory.OST_Windows)).ToList();


         foreach (var familyInstance in doorsWindows)
         {
            var dt = new DataWall(familyInstance);
            if (familyInstance.Host != null)
            {
               if (interiors.Any(x => x.Id == familyInstance.Host.Id.IntegerValue))
               {
                  interiors.Add(dt);

               }

               else if (exteriors.Any(x => x.Id == familyInstance.Host.Id.IntegerValue))
               {
                  exteriors.Add(dt);
               }
            }
         }


         var eles = new FilteredElementCollector(doc).WhereElementIsNotElementType().ToList();
         var dataLevels = new List<ElementLevelData>();
         foreach (var ele in eles)
         {
            var bb = ele.get_BoundingBox(null);
            if (bb != null)
            {
               var level = GetLevel(ele, levels);
               dataLevels.Add(new ElementLevelData()
               {
                  Id = ele.Id.IntegerValue,
                  Level = level
               });
            }
         }

         var dts = GetElementData(doc);

         var rs = JsonConvert.SerializeObject(new
         {
            Exs = exteriors,
            Ins = interiors,
            EleLevels = dataLevels,
            Datas = dts
         }, Formatting.None);

         File.WriteAllText("output.json", rs);

         e.Succeeded = true;
      }

      public static List<ElementId> GetOutermostWalls(Document doc, Level level)
      {
         var vft = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>()
            .FirstOrDefault(x => x.ViewFamily == ViewFamily.FloorPlan);
         double offset = 1000 / 304.8;
         List<Wall> wallList = new FilteredElementCollector(doc).OfClass(typeof(Wall)).Cast<Wall>().Where(x => x.WallType.Kind == WallKind.Basic).ToList();
         double maxX = -1D;
         double minX = -1D;
         double maxY = -1D;
         double minY = -1D;
         wallList.ForEach((wall) =>
         {
            Curve curve = (wall.Location as LocationCurve)?.Curve;
            XYZ xyz1 = curve.GetEndPoint(0);
            XYZ xyz2 = curve.GetEndPoint(1);

            double _minX = Math.Min(xyz1.X, xyz2.X);
            double _maxX = Math.Max(xyz1.X, xyz2.X);
            double _minY = Math.Min(xyz1.Y, xyz2.Y);
            double _maxY = Math.Max(xyz1.Y, xyz2.Y);

            if (curve.IsCyclic)
            {
               Arc arc = curve as Arc;
               double _radius = arc.Radius;
               //粗略对x和y 加/减
               _maxX += _radius;
               _minX -= _radius;
               _maxY += _radius;
               _minY += _radius;
            }

            if (Utils.IsEqual(minX, -1))
            {
               minX = _minX;
            }

            if (Utils.IsEqual(maxX, -1))
            {
               maxX = _maxX;
            }

            if (Utils.IsEqual(maxY, -1))
            {
               maxY = _maxY;
            }

            if (Utils.IsEqual(minY, -1))
            {
               minY = _minY;
            }

            if (_minX < minX) minX = _minX;
            if (_maxX > maxX) maxX = _maxX;
            if (_maxY > maxY) maxY = _maxY;
            if (_minY < minY) minY = _minY;
         });
         minX -= offset;
         maxX += offset;
         minY -= offset;
         maxY += offset;

         CurveArray curves = new CurveArray();
         Line line1 = Line.CreateBound(new XYZ(minX, maxY, 0), new XYZ(maxX, maxY, 0));
         Line line2 = Line.CreateBound(new XYZ(maxX, maxY, 0), new XYZ(maxX, minY, 0));
         Line line3 = Line.CreateBound(new XYZ(maxX, minY, 0), new XYZ(minX, minY, 0));
         Line line4 = Line.CreateBound(new XYZ(minX, minY, 0), new XYZ(minX, maxY, 0));
         curves.Append(line1); curves.Append(line2); curves.Append(line3); curves.Append(line4);

         using (TransactionGroup group = new TransactionGroup(doc))
         {

            Room newRoom = null;
            RoomTag tag1 = null;
            group.Start("find outermost walls");
            using (Transaction transaction = new Transaction(doc, "createNewRoomBoundaryLines"))
            {
               transaction.Start();

               var view = ViewPlan.Create(doc, vft.Id, level.Id);

               SketchPlane sketchPlane = SketchPlane.Create(doc, view.GenLevel.Id);

               ModelCurveArray modelCaRoomBoundaryLines = doc.Create.NewRoomBoundaryLines(sketchPlane, curves, view);

               XYZ point = new XYZ(minX + 600 / 304.8, maxY - 600 / 304.8, 0);

               newRoom = doc.Create.NewRoom(view.GenLevel, new UV(point.X, point.Y));

               tag1 = doc.Create.NewRoomTag(new LinkElementId(newRoom.Id), new UV(point.X, point.Y), view.Id);
               transaction.Commit();
            }
            List<ElementId> elementIds = DetermineAdjacentElementLengthsAndWallAreas(doc, newRoom);
            group.RollBack();
            return elementIds;
         }

      }

      static List<ElementId> DetermineAdjacentElementLengthsAndWallAreas(Document doc, Room room)
      {
         List<ElementId> elementIds = new List<ElementId>();

         IList<IList<BoundarySegment>> boundaries
           = room.GetBoundarySegments(new SpatialElementBoundaryOptions());

         int n = boundaries.Count;//.Size;

         int iBoundary = 0, iSegment;

         foreach (IList<BoundarySegment> b in boundaries)
         {
            ++iBoundary;
            iSegment = 0;
            foreach (BoundarySegment s in b)
            {
               ++iSegment;
               Element neighbour = doc.GetElement(s.ElementId);// s.Element;
               Curve curve = s.GetCurve();//.Curve;
               double length = curve.Length;

               if (neighbour is Wall)
               {
                  Wall wall = neighbour as Wall;

                  Parameter p = wall.get_Parameter(
                    BuiltInParameter.HOST_AREA_COMPUTED);

                  double area = p.AsDouble();

                  LocationCurve lc
                    = wall.Location as LocationCurve;

                  double wallLength = lc.Curve.Length;

                  elementIds.Add(wall.Id);
               }
            }
         }
         return elementIds;
      }

      private static void LogTrace(string format, params object[] args) { System.Console.WriteLine(format, args); }

      private string GetLevel(Element ele, List<Level> levels)
      {
         var z = ele.get_BoundingBox(null).Min.Z;
         var min = double.MaxValue;
         var l = levels.FirstOrDefault();
         foreach (var level in levels)
         {
            var levelZ = level.Elevation;
            if (Math.Abs(z - levelZ) < min)
            {
               min = Math.Abs(z - levelZ);
               l = level;
            }
         }

         return l.Name;
      }

      private List<BaseDto> GetElementData(Document doc)
      {
         var datas = new List<BaseDto>();
         var eles = new FilteredElementCollector(doc).WhereElementIsNotElementType().ToList();
         foreach (var element in eles)
         {
            try
            {
               var vl = GetAllSolids(element).Sum(x => x.Volume);
               if (vl > 0.01)
               {
                  var pArea = element.LookupParameter("Area");
                  var pLength = element.LookupParameter("Length");
                  var area = 0.0;
                  var length = 0.0;
                  if (pArea != null)
                  {
                     area = pArea.AsDouble();
                  }

                  if (pLength != null)
                  {
                     length = pLength.AsDouble();
                  }

                  var dt = new BaseDto()
                  {
                     Id = element.Id.IntegerValue,
                     Volume = vl,
                     Area = area,
                     Length = length
                  };

                  datas.Add(dt);
               }
            }
            catch (Exception e)
            {
            }

         }

         return datas;
      }

      public List<Solid> GetAllSolids(Element instance)
      {
         List<Solid> solidList = new List<Solid>();
         if (instance == null)
            return solidList;
         GeometryElement geometryElement = instance.get_Geometry(new Options()
         {
            ComputeReferences = true
         });

         foreach (GeometryObject geometryObject1 in geometryElement)
         {
            GeometryInstance geometryInstance = geometryObject1 as GeometryInstance;
            if (null != geometryInstance)
            {
               var tf = geometryInstance.Transform;
               foreach (GeometryObject geometryObject2 in geometryInstance.GetSymbolGeometry())
               {
                  Solid solid = geometryObject2 as Solid;
                  if (!(null == solid) && solid.Faces.Size != 0 && solid.Edges.Size != 0)
                  {
                     solidList.Add(solid);
                  }
               }
            }
            Solid solid1 = geometryObject1 as Solid;
            if (!(null == solid1) && solid1.Faces.Size != 0)
               solidList.Add(solid1);
         }
         return solidList;
      }

   }

   public class DataWall
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public double Height { get; set; }
      public string Category { get; set; }

      public DataWall()
      {

      }

      public DataWall(Element wall)
      {

         Id = wall.Id.IntegerValue;
         Name = wall.Name;
         var bb = wall.get_BoundingBox(null);
         if (bb != null)
         {
            Height = bb.Max.Z - bb.Min.Z;
         }

         Category = wall.Category.Name;
      }
   }

   public class BaseDto
   {
      public int Id { get; set; }
      public double Volume { get; set; }
      public double Length { get; set; }
      public double Area { get; set; }
   }


   public class ElementLevelData
   {
      public int Id { get; set; }
      public string Level { get; set; }
   }

}
