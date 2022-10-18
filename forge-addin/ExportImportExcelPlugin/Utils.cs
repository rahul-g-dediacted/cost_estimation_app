using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImageCastingReport
{
   public static class Utils
   {
      public static BuiltInCategory ToBuiltinCategory(this Category cat)
      {
         BuiltInCategory result = BuiltInCategory.INVALID;
         if (cat == null)
         {
            return result;
         }
         try
         {
            result = (BuiltInCategory)Enum.Parse(typeof(BuiltInCategory), cat.Id.ToString());
            return result;
         }
         catch
         {
            return result;
         }
      }

      public static bool IsEqual(this double A, double B, double tolerance = 0.001)
      {
         return Math.Abs(B - A) < tolerance;
      }
   }
}
