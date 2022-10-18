/* eslint-disable */
import $ from 'jquery';

import { getAllElementsInView } from './AutodeskForge';
import ExcelJS from 'exceljs/dist/es5/exceljs.browser';
import {
  handleGetDataCSV,
  handleGetScheduleDataCSV,
  handleGetMissingDataCSV,
} from '../services/backendService';
import axios from 'axios';
import Panel from './Panel';
import _ from 'lodash';
import { saveAs } from 'file-saver';
import { Modal, Button, notification } from 'antd';

// export to csv library
import { ExportToCsv } from 'export-to-csv';

const Autodesk = window.Autodesk;

var viewer = null;
let checkAnimation = false;
let dataAnimation = [];
let countAnimation = 0;
let viewer3D = null;
const showSpinner = () => {
  const spinner = document.getElementById('loading-screen-forge');
  if (spinner) spinner.style.display = 'block';
};
export const hideSpinner = () => {
  const spinner = document.getElementById('loading-screen-forge');
  if (spinner) spinner.style.display = 'none';
};

class ButtonForge extends Autodesk.Viewing.Extension {
  constructor(viewer, options) {
    super(viewer, options);
    this.viewer = viewer;
    Autodesk.Viewing.Extension.call(this, viewer, options);
  }
  load() {
    this.viewer.addEventListener(
      Autodesk.Viewing.AGGREGATE_SELECTION_CHANGED_EVENT,
      this.getSelections
    );
    this.viewer.addEventListener(
      Autodesk.Viewing.OBJECT_TREE_CREATED_EVENT,
      this.updateToDataBase
    );
    return true;
  }
  unload() {
    if (this.subToolbar) {
      this.viewer.toolbar.removeControl(this.subToolbar);
      this.subToolbar = null;
    }
    this.viewer.removeEventListener(
      Autodesk.Viewing.AGGREGATE_SELECTION_CHANGED_EVENT,
      this.getSelections
    );
    this.viewer.removeEventListener(
      Autodesk.Viewing.OBJECT_TREE_CREATED_EVENT,
      this.updateToDataBase
    );
    return true;
  }

  onToolbarCreated = function (toolbar) {
    viewer = this.viewer;
    viewer3D = this.viewer;
    var button1 = new Autodesk.Viewing.UI.Button('thirdButton');
    button1.addClass('fas');
    button1.addClass('fa-play');
    button1.addClass('fa-2x');
    button1.setToolTip('Animation');
    this.thirdButton = button1;
    button1.onClick = () => {
      this.handleAnimation();
    };

    let GetDataAsDynamoButton = new Autodesk.Viewing.UI.Button(
      'turnTableButton'
    );
    GetDataAsDynamoButton.addClass('fas');
    GetDataAsDynamoButton.addClass('fa-download');
    GetDataAsDynamoButton.addClass('fa-2x');
    // GetDataAsDynamoButton.addClass("buttonDownload");
    GetDataAsDynamoButton.setToolTip('Download Data as CSV');
    GetDataAsDynamoButton.onClick = () => {
      handleGetDataCSV();
    };

    let secondButton = new Autodesk.Viewing.UI.Button('secondButton');
    secondButton.addClass('far');
    secondButton.addClass('fa-calendar-alt');
    secondButton.addClass('fa-2x');
    // secondButton.addClass("buttonDownload");
    secondButton.setToolTip('Download Schedule Data as CSV');
    secondButton.onClick = function () {
      handleGetScheduleDataCSV();
    };

    let missingDataButton = new Autodesk.Viewing.UI.Button('missingButton');
    missingDataButton.addClass('fas');
    missingDataButton.addClass('fa-exclamation-circle');
    missingDataButton.addClass('fa-2x');
    missingDataButton.setToolTip('Download missing Data as CSV');
    missingDataButton.onClick = function () {
      handleGetMissingDataCSV();
    };

    let metadataExportExcelButton = new Autodesk.Viewing.UI.Button(
      'metadataButton'
    );
    metadataExportExcelButton.addClass('fas');
    metadataExportExcelButton.addClass('fa-file-excel');
    metadataExportExcelButton.addClass('fa-2x');
    metadataExportExcelButton.setToolTip('Download metadata');
    metadataExportExcelButton.onClick = () => {
      this.handleDownloadMetaData();
    };

    let cameraButton = new Autodesk.Viewing.UI.Button('cameraButton');
    cameraButton.addClass('fas');
    cameraButton.addClass('fa-camera');
    cameraButton.addClass('fa-2x');
    cameraButton.setToolTip('Camera');

    let runAIButton = new Autodesk.Viewing.UI.Button('runAIButton');
    // runAIButton.addClass("far");
    // runAIButton.addClass("fa-head-side-brain");
    // runAIButton.addClass("fa-2x");
    runAIButton.icon.style = `background-image: url(https://img.icons8.com/external-photo3ideastudio-lineal-photo3ideastudio/64/000000/external-ai-digital-business-photo3ideastudio-lineal-photo3ideastudio.png); background-size: 24px 24px;background-color:white`;
    runAIButton.setToolTip('Run AI');
    runAIButton.onClick = () => {
      const selectedProjectId = localStorage.getItem('selectedProjectId');

      axios
        .get('http://localhost:5000/updatedb/' + selectedProjectId)
        .then((res) => {
          if (res.data.updateMongo === 'Success') {
            axios
              .post('/api/function/animation/test/' + selectedProjectId)
              .then((res) => {
                this.setState({ percentage: res.data['Score'] });
                window.store.dispatch({
                  type: 'PERCENT',
                  payload: res.data['Score'],
                });
                this.setState({ circumference: res.data['Score'] + ', 100' });
              });

            notification['success']({
              message: 'Infomation',
              description: 'A.I engine has been filled data successfully!',
            });
          } else {
            notification['warning']({
              message: 'Infomation',
              description: 'A.I engine has failed!',
            });
            console.log('> Did not update Mongo DB');
          }
        })
        .catch((res) => {
          console.log('> Error Making the updateDB API call.');
        });
    };

    let ganttButton = new Autodesk.Viewing.UI.Button('ganttButton');
    // runAIButton.addClass("far");
    // runAIButton.addClass("fa-head-side-brain");
    // runAIButton.addClass("fa-2x");
    ganttButton.icon.style = `background-image: url(https://img.icons8.com/external-soft-fill-juicy-fish/60/000000/external-timeline-product-management-soft-fill-soft-fill-juicy-fish-2.png); background-size: 24px 24px;background-color:white`;
    ganttButton.setToolTip('Gantt Chart');

    let estimateButton = new Autodesk.Viewing.UI.Button('estimate');
    estimateButton.icon.style = `background-image: url(export-csv-icon-20.jpg); background-size: 24px 24px;background-color:white`;
    estimateButton.setToolTip('Estimate');
    estimateButton.onClick = () => {
      // loader
      estimateButton.icon.style = `background-image: url(http://prediction3d.com/loader.gif); background-size:24px; background-color:white`;

      // modal id
      const selectedModelId = localStorage.getItem("selectedModelId");
      
      // get cost data
      axios.get(
        "/api/function/animation/exportCSV/" + selectedModelId
      ).then((res)=>{

          // export to csv
          const options = { 
            fieldSeparator: ',',          
            useKeysAsHeaders: true,      
          };          
          const csvExp = new ExportToCsv(options);          
          csvExp.generateCsv(res.data);

          // icon revert
          estimateButton.icon.style = `background-image: url(export-csv-icon-20.jpg); background-size: 24px 24px;background-color:white`;
        })
    };

    let compairButton = new Autodesk.Viewing.UI.Button('compair');
    compairButton.icon.style = `background-image: url(compair.png); background-size: 24px 24px;background-color:white`;
    compairButton.setToolTip('Compare');
    compairButton.onClick = () => {
      console.log('compair click');
      console.log("window.store",window.store)

      window.store.dispatch({
        type: 'COMPAIR',
        payload: false,
      });

      window.store.dispatch({
        type: 'COMPAIR',
        payload: true,
      });
    };

    // _group
    this._group = new Autodesk.Viewing.UI.ControlGroup('CameraRotateToolbar');

    this.viewer.toolbar.addControl(this._group);

    let started = false;

    let rotateCamera = () => {
      if (started) {
        requestAnimationFrame(rotateCamera);
      }

      const nav = viewer3D.navigation;
      const up = nav.getCameraUpVector();
      const axis = new THREE.Vector3(0, 0, 1);
      const speed = (10.0 * Math.PI) / 180;
      const matrix = new THREE.Matrix4().makeRotationAxis(axis, speed * 0.1);

      let pos = nav.getPosition();
      pos.applyMatrix4(matrix);
      up.applyMatrix4(matrix);
      nav.setView(pos, new THREE.Vector3(0, 0, 0));
      nav.setCameraUpVector(up);
      var viewState = viewer3D.getState();
      // viewer.restoreState(viewState);
    };

    cameraButton.onClick = () => {
      started = !started;
      if (started) rotateCamera();
    };

    this.subToolbar = new Autodesk.Viewing.UI.ControlGroup(
      'custom-toolbar-sub'
    );
    this.subToolbar.addControl(button1);
    this.subToolbar.addControl(GetDataAsDynamoButton);
    this.subToolbar.addControl(secondButton);
    this.subToolbar.addControl(missingDataButton);
    this.subToolbar.addControl(metadataExportExcelButton);
    this.subToolbar.addControl(cameraButton);
    this.subToolbar.addControl(runAIButton);
    this.subToolbar.addControl(ganttButton);
    this.subToolbar.addControl(estimateButton);
    this.subToolbar.addControl(compairButton);
    viewer.toolbar.addControl(this.subToolbar);
  };

  handleAnimation = async () => {
    console.log('> Calling backend to retrieve sorted data');
    let allDbIds = getAllElementsInView(this.viewer);
    // console.log(allDbIds);
    let div = $('#animation-status');
    let btn = $('#thirdButton');
    if (div.width() === 0) {
      checkAnimation = true;
      this.playAnimation(div, allDbIds);
    } else if (btn.hasClass('fa-pause')) {
      checkAnimation = false;
      this.thirdButton.removeClass('fa-pause');
      this.thirdButton.addClass('fa-play');
    } else if (!checkAnimation) {
      checkAnimation = true;
      if (window.confirm('Do you want to reset animation?')) {
        this.playAnimation(div, allDbIds);
      } else {
        this.thirdButton.removeClass('fa-play');
        this.thirdButton.addClass('fa-pause');
        div[0].parentElement.style.display = 'none';
        while (countAnimation < dataAnimation.length && checkAnimation) {
          this.viewer.show(dataAnimation[countAnimation]);
          await this.timer(500);
          countAnimation++;
          let value = ((countAnimation / dataAnimation.length) * 100).toFixed(
            2
          );
          div.css('width', value + '%');
          div.text(value + '%');
          if (value === '100.00') {
            this.thirdButton.removeClass('fa-pause');
            this.thirdButton.addClass('fa-play');
            div.css('width', 0 + '%');
            div.text(0 + '%');
            div[0].parentElement.style.display = 'none';
          }
        }
      }
    }
  };

  playAnimation = (div, allDbIds) => {
    const selectedProjectId = localStorage.getItem('selectedProjectId');
    div.css('width', 0 + '%');
    div.text(0 + '%');
    axios
      .post('/api/function/animation/animationData/' + selectedProjectId)
      .then((res) => {
        let parse = JSON.parse(res.data);
        console.log(parse);
        let temp = [];
        dataAnimation = [];
        let count = allDbIds[0].selection.length;
        _.forEach(allDbIds[0].selection, (id) => {
          allDbIds[0].model.getProperties(id, async (modelAProperty) => {
            //get properties
            if (modelAProperty.name)
              temp.push({ id, name: modelAProperty.name });
            count--;
            if (count === 0) {
              _.forEach(parse, (i) => {
                let index = _.findIndex(temp, (o) => {
                  return i.Family === o.name;
                }); //matching name
                if (index >= 0) {
                  this.viewer.hide(temp[index].id);
                  dataAnimation.push(temp[index].id);
                }
              });
              countAnimation = 0;
              this.thirdButton.removeClass('fa-play');
              this.thirdButton.addClass('fa-pause');
              div[0].parentElement.style.display = 'block';
              while (countAnimation < dataAnimation.length && checkAnimation) {
                this.viewer.show(dataAnimation[countAnimation]);
                await this.timer(500);
                countAnimation++;
                let value = (
                  (countAnimation / dataAnimation.length) *
                  100
                ).toFixed(2);
                div.css('width', value + '%');
                div.text(value + '%');
                if (value === '100.00') {
                  this.thirdButton.removeClass('fa-pause');
                  this.thirdButton.addClass('fa-play');
                  div.css('width', 0 + '%');
                  div.text(0 + '%');
                  div[0].parentElement.style.display = 'none';
                }
              }
            }
          });
        });
      })
      .catch((err) => {
        console.log(err);
      });
  };
  timer(ms) {
    return new Promise((res) => setTimeout(res, ms));
  }

  downloadData = async () => {
    const elementSelected = this.getSelections();
    const elementDownload = elementSelected.length
      ? elementSelected
      : this.getAllElementsInView();
    const dataForDownload = await this.getElementForDownload(elementDownload);

    const fileRequest = JSON.stringify({ data: dataForDownload });
    var request = new XMLHttpRequest();
    request.open('POST', '/api/function/oldcode/download', true);
    request.setRequestHeader('Content-type', 'application/json');
    request.responseType = 'blob';
    request.send(fileRequest);
    request.onload = function (e) {
      if (this.status === 200) {
        var blob = this.response;
        var fileName = request.getResponseHeader('Content-Disposition');
        if (window.navigator.msSaveOrOpenBlob) {
          window.navigator.msSaveBlob(blob, fileName);
        } else {
          var downloadLink = window.document.createElement('a');
          var contentTypeHeader = request.getResponseHeader('Content-Type');
          downloadLink.href = window.URL.createObjectURL(
            new Blob([blob], { type: contentTypeHeader })
          );
          console.log(fileName);
          downloadLink.download = 'data.zip';
          document.body.appendChild(downloadLink);
          downloadLink.click();
          document.body.removeChild(downloadLink);
        }
      } else {
        throw 'error';
      }
    };
  };
  downloadExcel = async () => {
    const elementSelected = this.getSelections();
    const elementDownload = elementSelected.length
      ? elementSelected
      : this.getAllElementsInView();

    const dataForDownload = await this.getElementForDownload(elementDownload);

    const fileRequest = JSON.stringify({ data: dataForDownload });
    var request = new XMLHttpRequest();
    request.open('POST', '/api/function/oldcode/download', true);
    request.setRequestHeader('Content-type', 'application/json');
    request.responseType = 'blob';
    request.send(fileRequest);
    request.onload = function (e) {
      if (this.status === 200) {
        var blob = this.response;
        var fileName = request.getResponseHeader('Content-Disposition');
        if (window.navigator.msSaveOrOpenBlob) {
          window.navigator.msSaveBlob(blob, fileName);
        } else {
          var downloadLink = window.document.createElement('a');
          var contentTypeHeader = request.getResponseHeader('Content-Type');
          downloadLink.href = window.URL.createObjectURL(
            new Blob([blob], { type: contentTypeHeader })
          );
          downloadLink.download = 'download.xlsx';
          document.body.appendChild(downloadLink);
          downloadLink.click();
          document.body.removeChild(downloadLink);
        }
      } else {
        throw 'error';
      }
    };
  };

  getAllElementsInView = () => {
    const instanceTree = this.viewer.model.getData().instanceTree;
    //console.log(instanceTree);
    const rootId = instanceTree.getRootId();
    let alldbId = [];
    if (!rootId) {
      return [{ model: this.viewer.model, selection: alldbId }];
    }
    let queue = [];
    queue.push(rootId);
    while (queue.length > 0) {
      var node = queue.shift();
      if (instanceTree.getChildCount(node) !== 0) {
        instanceTree.enumNodeChildren(node, function (childrenIds) {
          queue.push(childrenIds);
        });
      } else {
        alldbId = [...alldbId, node];
      }
    }

    const allElements = [{ model: this.viewer.model, selection: alldbId }];
    return allElements;
  };

  async handleDownloadMetaData() {
    const elements = this.getAllElementsInView();
    const data = await this.getData(elements);

    const propertyAttract = [
      'Category',
      'CategoryId',
      'parent',
      'Level',
      'Location_Line',
      'Base_Constraint',
      'Base_Offset',
      'Base_is_Attached',
      'Base_Extension_Distance',
      'Top_Constraint',
      'Unconnected_Height',
      'Top_Offset',
      'Top_is_Attached',
      'Top_Extension_Distance',
      'Room_Bounding',
      'Related_to_Mass',
      'Structural',
      'Enable_Analytical_Model',
      'Structural_Usage',
      'Length',
      'Area',
      'Volume',
      'Type_Name',
      'Image',
      'Comments',
      'Mark',
      'Phase_Created',
      'Phase_Demolished',
      'Structure',
      'Wrapping_at_Inserts',
      'Wrapping_at_Ends',
      'Width',
      'Function',
      'Coarse_Scale_Fill_Pattern',
      'Coarse_Scale_Fill_Color',
      'Structural_Material',
      'Thermal_mass',
      'Absorptance',
      'Roughness',
      'Type_Image',
      'Keynote',
      'Model',
      'Manufacturer',
      'Type_Comments',
      'URL',
      'Description',
      'Assembly_Description',
      'Assembly_Code',
      'Type_Mark',
      'Fire_Rating',
      'Cost',
      'Length',
    ];

    const arrayUniqueByKey = [
      ...new Map(data.map((item) => [item['model_id'], item])).values(),
    ];

    const dataSave = arrayUniqueByKey.map((d) => {
      const { model_name, model_id, coordinate, properties, results, name } = d;
      let objProps = {
        model_name,
        model_id,
        Family: name,
      };

      let volumnParam = properties.find(
        (f) => f.displayName.replace(/\s/g, '_') === 'Volume'
      );

      let areaParam = properties.find(
        (f) => f.displayName.replace(/\s/g, '_') === 'Area'
      );

      let Unit_Of_Measure = '1 unit';

      if (
        volumnParam &&
        volumnParam.units &&
        !_.isNil(volumnParam.units) &&
        !_.isEmpty(volumnParam.units)
      ) {
        Unit_Of_Measure = volumnParam.units;
      }

      if (
        areaParam &&
        areaParam.units &&
        !_.isNil(areaParam.units) &&
        !_.isEmpty(areaParam.units)
      ) {
        Unit_Of_Measure = areaParam.units;
      }

      if (Unit_Of_Measure.includes('ft')) {
        Unit_Of_Measure = 'ft';
      } else if (Unit_Of_Measure.includes('m')) {
        Unit_Of_Measure = 'm';
      }

      propertyAttract.forEach((propName) => {
        let find = properties.find(
          (f) => f.displayName.replace(/\s/g, '_') === propName
        );

        let objNew = {
          [propName]: find ? find.displayValue : '',
        };

        let unitPropName = propName + '_Unit';
        if (find && find.units && find.units.length > 0) {
          objNew = {
            [propName]: find ? find.displayValue : '',
            [unitPropName]: find.units,
          };
        }

        objProps = { ...objProps, ...objNew, Unit_Of_Measure };
      });

      return objProps;
    });

    const workbook = new ExcelJS.Workbook();
    const worksheet = workbook.addWorksheet('Daily record');

    worksheet.columns = Object.keys(dataSave[0]).map((key) => ({
      header: key,
      key,
    }));

    dataSave.forEach((r) => {
      const newRows = worksheet.addRow(r);
    });

    const buf = await workbook.xlsx.writeBuffer();

    saveAs(new Blob([buf]), 'Metadata' + '.xlsx');
  }

  getSelections = () => {
    const selects = this.viewer.impl.selector.getAggregateSelection();
    return selects;
  };

  getElementForDownload = async (selects) => {
    const dbIds = selects[0].selection;
    const model = selects[0].model;

    return new Promise((resolveData) => {
      if (dbIds.length) {
        model.getBulkProperties(
          dbIds,
          {},
          (props) => {
            const results = this.getFragmentFromDbids(props, model);
            resolveData(results);
          },
          (err) => {
            //callback when error
            console.log(err);
            resolveData([]);
          }
        );
      } else {
        resolveData([]);
      }
    });
  };

  getAllProps = async (selects) => {
    const dbIds = selects[0].selection;
    const model = selects[0].model;

    return new Promise((resolveData) => {
      if (dbIds.length) {
        model.getBulkProperties(
          dbIds,
          {},
          (props) => {
            resolveData(props);
          },
          (err) => {
            //callback when error
            console.log(err);
            resolveData([]);
          }
        );
      } else {
        resolveData([]);
      }
    });
  };

  ///DYNAMO TEST

  getFragmentFromDbids = (data, model) => {
    const _this = this;
    const tree = model.getData().instanceTree;
    let points = [];
    const categoriesFilter = [];
    const dataFilter = data.filter((f) => {
      const findCate = f.properties.find((c) => c.displayName === 'Category');
      const category = findCate ? findCate.displayValue : null;
      return !categoriesFilter.includes(category) && category !== null;
    });

    dataFilter.forEach((element) => {
      const dbId = element.dbId;
      tree.enumNodeFragments(
        dbId,
        function (fragId) {
          const coordinate = _this.getApproximatePosition(fragId);
          points = [
            ...points,
            {
              coordinate,
              dbId,
              fragId,
              properties: element.properties,
              name: element.name,
            },
          ];
        },
        false
      );
    });
    const dataCal = _this.calculateResult(points);
    return dataCal;
  };
  getApproximatePosition = (fragid) => {
    const frags = this.viewer.model.getFragmentList();
    let bbox = new THREE.Box3();
    frags.getWorldBounds(fragid, bbox);
    return bbox.center();
  };

  calculateDistance = (p1, p2) => {
    var a = p2.x - p1.x;
    var b = p2.y - p1.y;
    var c = p2.z - p1.z;

    return Math.sqrt(a * a + b * b + c * c);
  };

  calculateResult = (points) => {
    //get distance for eachpoint
    const calResults = points.map((point_parent) => {
      const findTypeName = point_parent.properties.find(
        (f) => f.displayName === 'Type Name'
      );
      const model_name = findTypeName ? findTypeName.displayValue : '';
      const model_id = point_parent.name
        ? point_parent.name.split('[').length === 2
          ? point_parent.name.split('[')[1].replace(']', '')
          : ''
        : '';

      const distances = points
        .map((point_child) => {
          if (point_parent.dbId !== point_child.dbId) {
            const dis = this.calculateDistance(
              point_parent.coordinate,
              point_child.coordinate
            );
            return {
              from: point_parent.dbId,
              to: point_child.dbId,
              distance: dis,
            };
          } else {
            return null;
          }
        })
        .filter((f) => f !== null);

      return {
        model_name,
        model_id,
        coordinate: point_parent.coordinate,
        results: distances,
        properties: point_parent.properties,
        name: point_parent.name,
      };
    });
    return calResults;
  };
  getPosition = async (dbId, tree) => {
    return new Promise((resolveData) => {
      tree.enumNodeFragments(
        dbId,
        (fragId) => {
          const coordinate = this.getApproximatePosition(fragId);
          resolveData({ fragId, coordinate });
        },
        false
      );
    });
  };
  getData = async (selects) => {
    return new Promise((resolveData) => {
      const dbIds = selects[0].selection;
      const model = selects[0].model;
      const tree = model.getData().instanceTree;
      let temp = [];
      let count = dbIds.length;
      _.forEach(dbIds, (modelAdbId) => {
        model.getProperties(modelAdbId, (modelAProperty) => {
          if (modelAProperty.properties) {
            _.forEach(modelAProperty.properties, async (i) => {
              if (i.displayName === 'Category') {
                if (true) {
                  //categoriesFilter.includes(i.displayValue)
                  let { coordinate, fragId } = await this.getPosition(
                    modelAdbId,
                    tree
                  );
                  let point = {
                    coordinate,
                    modelAdbId,
                    fragId,
                    properties: modelAProperty.properties,
                    name: modelAProperty.name,
                  };

                  temp.push(point);
                  return false;
                }
              }
            });
          }
          count--;
          if (count === 0) {
            const dataCal = this.calculateResult(temp);
            resolveData(dataCal);
          }
        });
      });
    });
  };

  updateToDataBase = async () => {
    const selectedModel = JSON.parse(localStorage.getItem('selectedModel'));
    const selectedProjectId = localStorage.getItem('selectedProjectId');

    //check need to update data
    let split = window.location.pathname.split('/');
    const urn = split[2];
    const saveUrn = localStorage.getItem('urn');
    const elements = this.getAllElementsInView();
    const data = await this.getData(elements);

    console.log('elements', elements);

    if (!selectedModel || selectedModel.isHasMetadata == true) {
      return;
    }

    showSpinner();
    const propertyAttract = [
      'Category',
      'CategoryId',
      'parent',
      'Level',
      'Location_Line',
      'Base_Constraint',
      'Base_Offset',
      'Base_is_Attached',
      'Base_Extension_Distance',
      'Top_Constraint',
      'Unconnected_Height',
      'Top_Offset',
      'Top_is_Attached',
      'Top_Extension_Distance',
      'Room_Bounding',
      'Related_to_Mass',
      'Structural',
      'Enable_Analytical_Model',
      'Structural_Usage',
      'Length',
      'Area',
      'Volume',
      'Type_Name',
      'Image',
      'Comments',
      'Mark',
      'Phase_Created',
      'Phase_Demolished',
      'Structure',
      'Wrapping_at_Inserts',
      'Wrapping_at_Ends',
      'Width',
      'Function',
      'Coarse_Scale_Fill_Pattern',
      'Coarse_Scale_Fill_Color',
      'Structural_Material',
      'Thermal_mass',
      'Absorptance',
      'Roughness',
      'Type_Image',
      'Keynote',
      'Model',
      'Manufacturer',
      'Type_Comments',
      'URL',
      'Description',
      'Assembly_Description',
      'Assembly_Code',
      'Type_Mark',
      'Fire_Rating',
      'Cost',
      'Length',
    ];

    const arrayUniqueByKey = [
      ...new Map(data.map((item) => [item['model_id'], item])).values(),
    ];

    const dataSave = arrayUniqueByKey.map((d) => {
      const { model_name, model_id, coordinate, properties, results, name } = d;
      let objProps = {
        model_name,
        model_id,
        coordinate,
        centroids_distance_list: results,
        Family: name,
      };

      let volumnParam = properties.find(
        (f) => f.displayName.replace(/\s/g, '_') === 'Volume'
      );

      let areaParam = properties.find(
        (f) => f.displayName.replace(/\s/g, '_') === 'Area'
      );

      let Unit_Of_Measure = '1 unit';

      if (
        volumnParam &&
        volumnParam.units &&
        !_.isNil(volumnParam.units) &&
        !_.isEmpty(volumnParam.units)
      ) {
        Unit_Of_Measure = volumnParam.units;
      }

      if (
        areaParam &&
        areaParam.units &&
        !_.isNil(areaParam.units) &&
        !_.isEmpty(areaParam.units)
      ) {
        Unit_Of_Measure = areaParam.units;
      }

      if (Unit_Of_Measure.includes('ft')) {
        Unit_Of_Measure = 'ft';
      } else if (Unit_Of_Measure.includes('m')) {
        Unit_Of_Measure = 'm';
      }

      propertyAttract.forEach((propName) => {
        let find = properties.find(
          (f) => f.displayName.replace(/\s/g, '_') === propName
        );

        let objNew = {
          [propName]: find ? find.displayValue : '',
        };

        let unitPropName = propName + '_Unit';
        if (find && find.units && find.units.length > 0) {
          objNew = {
            [propName]: find ? find.displayValue : '',
            [unitPropName]: find.units,
          };
        }

        objProps = { ...objProps, ...objNew, Unit_Of_Measure, Location: -1 };
      });

      return objProps;
    });

    this.requestClearDataBaseAJAX(
      dataSave,
      selectedModel.key,
      selectedProjectId
    );
    this.craeteDownloadPanel(arrayUniqueByKey);
  };

  craeteDownloadPanel = (data) => {
    function onlyUnique(value, index, self) {
      return self.indexOf(value) === index;
    }

    const categories = data
      .map((d) => {
        const find = d.properties.find((f) => f.displayName === 'Category');
        const category = find ? find.displayValue : '';
        return category;
      })
      .filter(onlyUnique);
    const viewer = this.viewer;
    let panel = this.panel;
  };

  saveNewData = (data) => {
    this.requestUpdateDataBaseAJAX(JSON.stringify(data));
  };

  requestUpdateDataBase = async (data) => {
    const fileRequest = JSON.stringify({ data });
    var request = new XMLHttpRequest();
    request.open('POST', '/api/function/oldcode/updateDataBase', true);
    request.setRequestHeader('Content-type', 'application/json');
    request.responseType = 'blob';
    request.send(fileRequest);
    request.onload = function (e) {
      if (this.status === 200) {
        console.log('upload data successful ...');
      } else {
        console.log('upload data failed ...');
        throw 'error';
      }
    };
  };

  requestUpdateDataBaseAJAX = async (data, isFinal) => {
    $.ajax({
      url: '/api/function/oldcode/updateDataBase',
      type: 'POST',
      data: data,
      contentType: 'application/json',
      success: () => {
        if (isFinal) {
        }
      },
      error: (err) => {
        console.log(err);

        hideSpinner();
      },
    });
  };

  requestClearDataBaseAJAX = async (data, modelId, projectId) => {
    axios
      .post('/api/function/oldcode/checkDuplicates', {
        projectId,
        modelId,
      })
      .then((res) => {
        this.saveNewData({
          projectId,
          modelId,
          data,
        });
      })
      .catch((err) => {
        console.log(err);
      });
  };
}

Autodesk.Viewing.theExtensionManager.registerExtension(
  'ButtonForge',
  ButtonForge
);

export default 'ButtonForge';
