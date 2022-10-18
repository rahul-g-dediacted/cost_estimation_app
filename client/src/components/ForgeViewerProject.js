import React from 'react';
import _ from 'lodash';
import Split from 'react-split';
import { Box } from '@material-ui/core';
import { InboxOutlined } from '@ant-design/icons';
import queryString from 'query-string';
import LoadingOverlay from 'react-loading-overlay';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import {
  Classes,
  Intent,
  Toaster,
  Position,
  Spinner,
  Overlay,
} from '@blueprintjs/core';
import TableMaterial from './TableMaterial';
import TableAssemblyCode from './TableAssemblyCode';
import PieChart from './PieChart';
import DialogCompare3D from './DialogCompare3D';
import DialogCompare2D from './DialogCompare2D';
import PercentageCircle from './PercentageCircle';
import '../scss/ForgeViewer.scss';
import {
  getForgeToken,
  getAllElementdbIdsOneModel,
  sortChildrenCount,
  socket,
} from '../functions/AutodeskForge';
import ButtonForge, { hideSpinner } from '../functions/ButtonForge';
import WalkingPathToolExtension from '../functions/WalkingPathToolExtension';
import CameraTweenToolExtension from '../functions/CameraTweenToolExtension';
import { Dimmer, Loader } from 'semantic-ui-react';
import {
  message,
  Typography,
  Button,
  Select,
  Drawer,
  Space,
  Upload,
  Progress,
} from 'antd';

import {
  ExpandAltOutlined,
  RightOutlined,
  LeftOutlined,
  ReloadOutlined,
} from '@ant-design/icons';
import axios from 'axios';
import { Tree, Tooltip } from 'antd';
import {
  increaseCount,
  decreaseCount,
  resetCount,
  compair,
} from '../actions/index';

// select projects and please wait for dynamos modal - imports
import Modal from 'react-modal';
import closeIcon from '../image/close.png';

// document export modal styles
import {docExportModalStyles} from './styles/ForgeViewerProject.js';
import { Radio } from 'antd';
import FileSaver from 'file-saver';

// select projects and please wait for dynamos modal - styles
const modalStyles = {
  overlay:{
    display:'flex',
    justifyContent:'center',
    alignItems:'center'
  },
  content:{
    width:'50%',
    height:'50%',
    backgroundColor:'#1890ff',
    position:'none',
    display:'flex',
    flexDirection:'column',    
    alignItems:'center',
  },
  img:{
    display:'block',
    alignSelf:'flex-end',
    cursor:'pointer'
  },
  h2:{
    color:'white',
    height:'75%',
    display:'flex',
    alignItems:'center'    
  }
};

const { DirectoryTree } = Tree;

const { Dragger } = Upload;
const { Text } = Typography;
const Autodesk = window.Autodesk;
const { Option } = Select;
let selection1Locked = false;
let selection2Locked = false;

let globalState = 'abc';

const log = console.log.bind(this);

class ForgeViewerProject extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      urn2: '',
      dialogCompare: false,
      dialogCompare2d: false,
      selectedTableType: 'material',
      isOverlay: false,
      percent: 0,
      percentStatus: 'Uploading model',
      loading: false,
      loading: false,
      viewer: null,
      viewer2D: null,
      heightTable: 0,
      widthTable: 0,
      dataTable: [],
      dataTableAssemblyCode: [],
      dataLevelPieChart: [],
      dataPieChart: [],
      dataCategoryPieChart: [],
      isCollapse: true,
      testData: '',
      loadTableAssemblyCode: 0,
      loadTableMaterial: 0,
      selectedCategory: 'material',
      projectListVisible: false,
      projectList: [],
      modelList: [],
      selectedProjectId: null,
      selectedModelId: null,
      file: [],
      isExpandMenuLeft: false,
      dataPile: [],
      treeData: [],
      indexExpand: 1,
      selectedProject: {},
      selectedModel: {},
      // select projects and please wait for dynamos modal - state's
      modalState:true,
      modalText:'Please select projects from the top left menu.',
      // state of score component
      percentageCircleState:false,
      // document export modal
      docExportModalState:false,
      docExportModalRadioValue:'category',
      docExportModalWait: false      
    };
    this.toaster = React.createRef();
    this.tableRef = React.createRef();
    this.split1 = React.createRef();
    this.split2 = React.createRef();
    // percentage circle state handler - to call from child
    this.percentageCircleStateHandler = this.percentageCircleStateHandler.bind(this);
    // please wait modal after initalizing python dynamos completion
    this.AIWaitModalHandler = this.AIWaitModalHandler.bind(this);
    //
    this.testing = this.testing.bind(this);
    // missing assembly codes of user to fill
    this.MissingAssemblyCodeHandler = this.MissingAssemblyCodeHandler.bind(this);
  }

  getModelsForCompare() {
    if (this.state.selectedProject) {
      return this.state.selectedProject.children.map((x) => x.original);
    }
    return [];
  }

  componentDidMount = () => {
    this.getProjectListAtDidMount();

    this.setState({
      heightTable: this.tableRef.current.clientHeight,
      widthTable: this.tableRef.current.clientWidth,
    });
  };

  async getProjectList() {
    await axios.get('/api/function/animation/project-get-all').then((res) => {
      if (Array.isArray(res.data)) {
        let trees = res.data.map((x) => ({
          title: x.ProjectName,
          key: x._id,
          children: x.Models.map((y) => ({
            title: y.modelName,
            key: y.objectKey,
            isLeaf: true,
            urn: y.id,
            isHasMetadata: y.isHasMetadata,
            original: y,
          })),
        }));

        this.setState({ projectList: trees });

        return trees;
      }
    });

    return [];
  }

  async getProjectListAtDidMount() {
    axios.get('/api/function/animation/project-get-all').then((res) => {
      if (Array.isArray(res.data)) {
        let trees = res.data.map((x) => ({
          title: x.ProjectName,
          key: x._id,
          children: x.Models.map((y) => ({
            title: y.modelName,
            key: y.objectKey,
            isLeaf: true,
            urn: y.id,
            isHasMetadata: y.isHasMetadata,
            original: y,
          })),
        }));

        this.setState({ projectList: trees });

        let params = queryString.parse(this.props.location.search);

        this.setState({
          selectedProjectId: params.projectId,
          selectedModelId: params.urn,
        });

        let currentProject = trees.find((x) => x.key == params.projectId);

        if (currentProject) {
          let currentModel = currentProject.children.find(
            (x) => x.urn == params.urn
          );

          this.setState({
            selectedModel: currentModel,
            selectedModelId: currentModel?.key,
            selectedProjectId: currentProject.key,
            selectedProject: currentProject,
            selectedModel: currentModel,
          });

          localStorage.setItem('selectedModelId', currentModel?.key);
        }

        localStorage.setItem('selectedProjectId', params.projectId);

        //set local storage

        this.launchViewer(params.urn);

        return trees;
      }
    });

    return [];
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (this.state.selectedProjectId !== prevState.selectedProjectId) {
    }
  }

  componentWillMount = () => {
    socket.on('realtime-upload', this.realtimeUpload);
    socket.on('realtime-translate', this.realtimeTranslate);
    socket.on('realtime-translate-process', this.realtimeTranslateProgress);
    // call from backend after dynamos loaded - to load the score component
    socket.on('realtime-upload-db',()=>{
      this.setState({modalState:false,percentageCircleState:true});      
    });
  };
  componentWillUnmount = () => {
    socket.removeListener('realtime-upload', this.realtimeUpload);
    socket.removeListener('realtime-translate', this.realtimeTranslate);
    socket.removeListener(
      'realtime-translate-process',
      this.realtimeTranslateProgress
    );
  };

  realtimeUpload = (data) => {
    let urn = data.id;
    message.success('Upload file was success');
    console.log('translate ......');
    axios
      .post(`/api/forge/modelderivative/jobs`, { objectName: urn })
      .catch(() => {
        this.setState({ loading: false });
        message.error('Translate file was failed');
      });
  };

  realtimeTranslateProgress = (data) => {
    this.setState({ percentStatus: data.progress });
  };

  realtimeTranslate = (data) => {
    this.setState({ loading: false });
    message.success('Translate file was success');
  };

  //#region viewer
  //start viewer
  launchViewer = (urn) => {
    if (!urn) {
      return;
    }
    console.log('urn', urn);
    var options = {
      env: 'AutodeskProduction',
      getAccessToken: getForgeToken,
    };

    Autodesk.Viewing.Initializer(options, () => {
      let viewer = new Autodesk.Viewing.GuiViewer3D(
        document.getElementById('forgeViewer'),
        {
          extensions: [
            'Autodesk.DocumentBrowser',
            'Autodesk.VisualClusters',
            'Autodesk.AEC.LevelsExtension',
            'Autodesk.Viewing.MarkupsGui',
            'Autodesk.Viewing.MarkupsCore',
            'Autodesk.ADN.CameraTweenTool',
            'Autodesk.ADN.WalkingPathToolExtension',
          ],
        }
      );

      this.setState({ viewer }, () => {
        viewer.start();
        var documentId = 'urn:' + urn;
        Autodesk.Viewing.Document.load(
          documentId,
          this.onDocumentLoadSuccess.bind(this, urn),
          this.onDocumentLoadFailure
        );
      });
    });
  };

  onDocumentLoadSuccess = (urn, doc) => {
    let viewables = doc.getRoot().getDefaultGeometry();
    this.state.viewer.loadExtension('TransformationExtension');
    this.state.viewer.loadExtension(ButtonForge);
    this.state.viewer.loadExtension(CameraTweenToolExtension);
    this.state.viewer.loadExtension(WalkingPathToolExtension);

    this.state.viewer.loadDocumentNode(doc, viewables).then(() => {
      this.state.viewer.addEventListener(
        Autodesk.Viewing.OBJECT_TREE_CREATED_EVENT,
        this.handleFunction
      );

      this.launchViewer2D(urn);
    });

    doc.downloadAecModelData();
  };

  onDocumentLoadFailure = (viewerErrorCode, viewerErrorMsg) => {
    console.error(
      'onDocumentLoadFailure() - errorCode:' +
        viewerErrorCode +
        '\n- errorMessage:' +
        viewerErrorMsg
    );
  };
  //#endregion

  //start viewer 2d
  launchViewer2D = (urn) => {
    var options = {
      env: 'AutodeskProduction',
      getAccessToken: getForgeToken,
    };

    Autodesk.Viewing.Initializer(options, () => {
      let viewer2D = new Autodesk.Viewing.GuiViewer3D(
        document.getElementById('forgeViewer2D'),
        {
          extensions: [
            'Autodesk.DocumentBrowser',
            'Autodesk.Viewing.MarkupsGui',
            'Autodesk.Viewing.MarkupsCore',
            'Autodesk.AEC.LevelsExtension',
            'Autodesk.Viewing.PixelCompare',
          ],
        }
      );
      this.setState({ viewer2D }, () => {
        viewer2D.start();
        var documentId = 'urn:' + urn;
        Autodesk.Viewing.Document.load(
          documentId,
          this.onDocumentLoadSuccess2D,
          this.onDocumentLoadFailure2D
        );
      });
    });
  };

  onDocumentLoadSuccess2D = (doc) => {
    let viewables = doc
      .getRoot()
      .search({ type: 'geometry', role: '2d' }, true);
    if (viewables.length !== 0) {
      console.log('viewables', viewables);
      this.state.viewer2D.loadDocumentNode(doc, viewables[0]).then(() => {
        this.state.viewer2D.addEventListener(
          Autodesk.Viewing.OBJECT_TREE_CREATED_EVENT,
          this.callback2DView
        );
      });

      //pixel extension
      this.state.viewer2D
        .loadExtension('Autodesk.Viewing.PixelCompare')
        .then((e) => this.onPixelCompareExtensionLoaded(e))
        .catch((e) => console.log('load pixel compare fail', e));
    } else {
      message.warning(`No 2D view`);
    }
  };

  onPixelCompareExtensionLoaded(pixelCompareExt) {
    console.log('pixelCompareExt', pixelCompareExt);
    var offsetMode = false;

    function onKeyDown(event) {
      if (!event.keyCode) return;
      if (event.keyCode < 49 || event.keyCode > 54) return;

      if (event.keyCode == 49) {
        offsetMode = !offsetMode;
        pixelCompareExt.setChangeOffsetMode(offsetMode);
      } else pixelCompareExt.setDiffMode(event.keyCode - 49);
    }
    window.addEventListener('keydown', onKeyDown);

    pixelCompareExt
      .compareModelWithCurrent(this.state.urn2)
      .then(function (result) {
        console.log(
          `compare models ${result ? 'successful, yeah' : 'failed, boo'}`
        );
      });
  }

  callback2DView = () => {
    this.state.viewer2D.removeEventListener(
      Autodesk.Viewing.OBJECT_TREE_CREATED_EVENT,
      this.callback2DView
    );
    this.state.viewer.addEventListener(
      Autodesk.Viewing.SELECTION_CHANGED_EVENT,
      this.handleSelect2D
    );
  };
  handleSelect2D = (e) => {
    try {
      let currSelection = e.target.getSelection();
      if (e.target.clientContainer.id === 'forgeViewer') {
        if (selection2Locked) {
          selection2Locked = false;
          return;
        }
        selection1Locked = true;
        if (currSelection.length === 0) {
          this.state.viewer2D.clearSelection();
          // this.state.viewer2D.showAll()
          this.state.viewer2D.fitToView(
            null,
            this.state.viewer2D.impl.model,
            false
          );
          return;
        } else {
          this.state.viewer2D.select(currSelection);
          // this.state.viewer2D.isolate(currSelection, this.state.viewer2D.impl.model)
          this.state.viewer2D.fitToView(
            currSelection,
            this.state.viewer2D.impl.model,
            false
          );
          return;
        }
      } else {
        if (selection1Locked) {
          selection1Locked = false;
          return;
        }
        selection2Locked = true;
        if (currSelection.length === 0) {
          this.state.viewer.clearSelection();
          this.state.viewer.showAll();
          this.state.viewer.fitToView(
            null,
            this.state.viewer.impl.model,
            false
          );
          return;
        } else {
          this.state.viewer.select(currSelection);
          //this.state.viewer.isolate(currSelection, this.state.viewer.impl.model)
          this.state.viewer.fitToView(
            currSelection,
            this.state.viewer.impl.model,
            false
          );
          return;
        }
      }
    } catch {}
  };
  onDocumentLoadFailure2D = (viewerErrorCode, viewerErrorMsg) => {
    console.error(
      'onDocumentLoadFailure() - errorCode:' +
        viewerErrorCode +
        '\n- errorMessage:' +
        viewerErrorMsg
    );
  };
  //#endregion
  handleFunction = () => {
    this.generalTable(this.state.viewer);
  };
  //Create table
  generalTable = async (viewer) => {
    let dbIds = getAllElementdbIdsOneModel(viewer); // get all last node in viewer
    let count = dbIds.length;
    let temp = [];
    let tempCategory = [];
    let tempLevel = [];
    const listCategoryIgnore = [
      // 'Revit Level',
      // 'Revit Center Line',
      // 'Revit Insulation'
    ];
    let categories = [];
    _.forEach(dbIds, (modelAdbId) => {
      viewer.model.getProperties(modelAdbId, (modelAProperty) => {
        if (modelAProperty.properties) {
          let check = false;
          let checkCategory = false;

          _.forEach(modelAProperty.properties, (o) => {
            if (o.displayName === 'Category') {
              if (listCategoryIgnore.includes(o.displayValue)) {
                checkCategory = true;
                return false;
              } else {
                if (!categories.includes(o.displayValue))
                  categories.push(o.displayValue);
                return false;
              }
            }
          });
          if (!checkCategory) {
            _.forEach(modelAProperty.properties, (o) => {
              if (o.displayName === 'Structural Material') {
                temp.push({
                  id: modelAdbId,
                  material: o.displayValue ? o.displayValue : 'None',
                  name: modelAProperty.name,
                  price: 0,
                  parentId: o.displayValue ? o.displayValue : 'None',
                });
                check = true;
                return false;
              }
            });

            let categoryPara = modelAProperty.properties.find(
              (x) => x.displayName === 'Category'
            );
            if (categoryPara) {
              tempCategory.push({
                id: modelAdbId,
                category: categoryPara.displayValue
                  ? categoryPara.displayValue
                  : 'None',
                name: modelAProperty.name,
                price: 0,
                parentId: categoryPara.displayValue
                  ? categoryPara.displayValue
                  : 'None',
              });
            }

            let levelPara = modelAProperty.properties.find(
              (x) => x.displayName === 'Level'
            );

            if (levelPara) {
              tempLevel.push({
                id: modelAdbId,
                level: levelPara.displayValue ? levelPara.displayValue : 'None',
                name: modelAProperty.name,
                price: 0,
                parentId: levelPara.displayValue
                  ? levelPara.displayValue
                  : 'None',
              });
            }

            if (!check) {
              temp.push({
                id: modelAdbId,
                material: 'None',
                name: modelAProperty.name,
                price: 0,
                parentId: 'None',
              });
            }
          }
        } else {
          temp.push({
            id: modelAdbId,
            material: 'None',
            name: modelAProperty.name,
            price: 0,
            parentId: 'None',
          });
        }

        count--;
        if (count === 0) {
          let t = {};
          _.forEach(temp, (i) => {
            if (!t[i.material]) t[i.material] = [];
            t[i.material].push(i);
          });
          // let t = groupArray(temp, 'material'); // group follow material
          let tempData = [];
          _.forEach(t, (v, k) => {
            tempData.push({
              id: k,
              material: k,
              name: `Count: ${v.length}`,
              price: 0,
              parentId: null,
              children: v,
            });
          });

          tempData.sort(sortChildrenCount);
          let tempPieChart = [];

          //let clone = tempData.slice(0, 5)
          let clone = {
            idx: 5,
            name: 'Other',
            value: 0,
            data: { children: [] },
          };

          _.forEach(tempData, (v, k) => {
            if (k < 5)
              tempPieChart.push({
                idx: k,
                name: v.material,
                value: v.children.length,
                data: v,
              });
            else {
              clone.value = clone.value + v.children.length;
              clone.data.children = clone.data.children.concat(v.children);
            }
          });

          if (clone.value > 0) {
            tempPieChart.push(clone);
          }

          let tempCategoryPieChart = [];
          let dic = _.groupBy(tempCategory, 'category');
          Object.keys(dic).forEach((key, index) => {
            let items = dic[key];

            tempCategoryPieChart.push({
              idx: index,
              name: key,
              value: items.length,
              data: {
                children: items,
              },
            });
          });

          let tempLevelPieChart = [];
          let dicLevel = _.groupBy(tempLevel, 'level');
          Object.keys(dicLevel).forEach((key, index) => {
            let items = dicLevel[key];

            tempLevelPieChart.push({
              idx: index,
              name: key,
              value: items.length,
              data: {
                children: items,
              },
            });
          });

          if (true) {
            let total = _.sumBy(tempPieChart, 'data.children.length');
            tempPieChart.forEach((x) => {
              x.name =
                x.name +
                ':' +
                _.round((x.data.children.length * 100) / total, 1) +
                '%' +
                ' (' +
                x.data.children.length +
                ')';
            });
          }

          if (true) {
            let total = _.sumBy(tempCategoryPieChart, 'data.children.length');
            tempCategoryPieChart.forEach((x) => {
              x.name =
                x.name +
                ':' +
                _.round((x.data.children.length * 100) / total, 1) +
                '%' +
                ' (' +
                x.data.children.length +
                ')';
            });
          }

          if (true) {
            let total = _.sumBy(tempLevelPieChart, 'data.children.length');
            tempLevelPieChart.forEach((x) => {
              x.name =
                x.name +
                ':' +
                _.round((x.data.children.length * 100) / total, 1) +
                '%' +
                ' (' +
                x.data.children.length +
                ')';
            });
          }

          this.setState({
            dataTable: tempData,
            dataPieChart: tempPieChart,
            dataCategoryPieChart: tempCategoryPieChart,
            dataLevelPieChart: tempLevelPieChart,
          });
        }
      });
    });
  };

  dragSplit = () => {
    try {
      this.state.viewer.resize();
      this.state.viewer2D.resize();
    } catch {}
  };
  dragSplit1 = () => {
    try {
      this.setState({
        heightTable: this.tableRef.current.clientHeight,
        widthTable: this.tableRef.current.clientWidth,
      }); // get width and height for table resize
      this.state.viewer2D.resize();
    } catch {}
  };
  handleExpand = (index) => {
    if (this.split2.current) {
      let size = [25, 25, 25, 25];
      if (index === 0) {
        size = [97, 1, 1, 1];
      } else if (index === 1) {
        size = [1, 97, 1, 1];
      } else if (index === 2) {
        size = [1, 1, 97, 1];
      } else if (index === 3) {
        size = [1, 1, 1, 97];
      }
      this.split2.current.split.setSizes(size);
    }
  };
  async handleLoadAssemblyCode() {
    this.setState({
      loadTableAssemblyCode: this.state.loadTableAssemblyCode + 1,
    });
  }

  async handleLoadMaterial() {
    this.setState({
      loadTableMaterial: this.state.loadTableMaterial + 1,
    });
  }
  handleExpandMainViewer = () => {
    this.setState({ isCollapse: !this.state.isCollapse }, () => {
      if (this.split1.current) {
        if (this.state.isCollapse) {
          this.split1.current.split.setSizes([60, 40]);
        } else {
          this.split1.current.split.setSizes([100, 0]);
        }
      }
      try {
        this.state.viewer.resize();
        this.state.viewer2D.resize();
      } catch {}
    });
  };
  handleTest = () => {
    axios
      .post('/api/function/animation/test/' + this.state.selectedProjectId)
      .then((res) => {
        let temp = [];
        _.forEach(res.data, (v, k) => {
          if (v !== null)
            temp.push(
              k.toString() + ': ' + (v !== null ? v.toString() + ' %' : '')
            );
        });
        this.setState({ testData: temp.join('\n') });
      });
  };

  handleChangeCategory = (e) => {
    let dt = this.getDataPieChart(e);
    this.setState({ dataPile: [...dt] });
    this.setState({ selectedCategory: e });
  };

  beforeUpload = (file, fileList) => {
    this.setState({ file: [...this.state.file, ...fileList] });
    return false;
  };
  handleUploadFile = async () => {
    if (Array.isArray(this.state.file)) {
      let i = 0;
      for (let file of this.state.file) {
        var data = new FormData();
        data.append('fileToUpload', file);
        if (data !== undefined || data !== null) {
          try {
            let res = await axios.post(
              `/api/forge/oss/objects/` + this.state.selectedProjectId,
              data
            );

            axios
              .post(`/api/forge/modelderivative/jobs`, {
                objectName: res.data.id,
              })
              .catch(() => {
                message.error('Translate file was failed');
              });

            let inputRvtCurrent = `https://developer.api.autodesk.com/oss/v2/buckets/${res.data.bucketKey.toLowerCase()}/objects/${
              res.data.objectKey
            }`;

            let payload = {
              inputRvt: inputRvtCurrent,
              appBundleName: 'ExportImagesCastingReport_2020Activity',
            };

            axios
              .post('/api/forge/da4revit/v1/revit/ex-in', payload)
              .then((r) => {});
          } catch (error) {
            console.log('upload fail', error);
          }
        }
        i++;
        this.setState({ percent: (100 * i) / this.state.file.length });
      }
      //reload current project

      axios.get('/api/function/animation/project-get-all').then((res) => {
        if (Array.isArray(res.data)) {
          this.setState({ projectList: res.data });

          let currentProject = res.data.find(
            (x) => x._id == this.state.selectedProjectId
          );

          this.setState({
            modelList: currentProject.Models.map((x) => ({
              label: x.text,
              value: x.id,
            })),
          });
        }
      });
    }

    //add files to projects
  };

  onSelect(e, info) {
    let currentProject = this.state.projectList.find((x) =>
      x.children.some((c) => c.key == e[0])
    );
    if (!currentProject || !currentProject.children) {
      return;
    }
    let currentModel = currentProject.children.find((x) => x.key == e);
    console.log('currentModel', currentProject);
    this.setState({
      selectedModelId: currentModel.urn,
      selectedProjectId: currentProject.key,
      selectedProject: currentProject,
      selectedModel: currentModel,
    });
    localStorage.setItem('selectedProjectId', currentProject.key);
    localStorage.setItem('selectedModelId', currentModel.key);
    localStorage.setItem('selectedModel', JSON.stringify(currentModel));
    localStorage.setItem('projectList', JSON.stringify(this.state.projectList));
    this.launchViewer(currentModel.urn);

    // if dynamos loaded - score component
    // else - please wait modal
    const selectedModel = JSON.parse(localStorage.getItem('selectedModel'));
    if(selectedModel.isHasMetadata===true){
      this.setState({percentageCircleState:true})
    }else{
      this.setState({modalState:true,modalText:'Please wait'});
    }

    if (currentModel.isHasMetadata != true) {
      try {
        let inputRvtCurrent = `https://developer.api.autodesk.com/oss/v2/buckets/${currentModel.original.bucketKey.toLowerCase()}/objects/${
          currentModel.original.objectKey
        }`;

        let payload = {
          inputRvt: inputRvtCurrent,
          appBundleName: 'ExportImagesCastingReport_2020Activity',
        };

        axios
          .post('/api/forge/da4revit/v1/revit/ex-in', payload)
          .then((r) => {});
      } catch (error) {}
    }
  }

  getDataPieChart(e) {
    if (e === 'material') {
      return this.state.dataPieChart;
    }

    if (e === 'category') {
      return this.state.dataCategoryPieChart;
    }

    if (e === 'level') {
      return this.state.dataCategoryPieChart;
    }
    return [];
  }

  // percentage circle state handler - to call from child
  percentageCircleStateHandler(){
    // setting the percentage circle state to false for next call
    this.setState({percentageCircleState:false});
  }

  // please wait modal handler after initalizing 
  // python dynamos completion - to call from PercentageCircle child
  AIWaitModalHandler(modal){
    if(modal==='visible'){
      this.setState({modalState:true,modalText:'Please wait'});
    } else if(modal==='disable'){
      this.setState({modalState:false});
    } else {
      return;
    }
  };

  MissingAssemblyCodeHandler(){
    log('MissingAssemblyCodeHandler');
    this.setState({
      modalState:true,
      modalText:'Please fill in the missing assembly codes in bottom right "Table Assembly Codes"\
                  section after clicking the refresh button'
    })
  }

  async testing(fileType){
    log('exportCostData');
    let downloadOption = this.state.docExportModalRadioValue;
    if(fileType==='pdf'||fileType==='excel'){
      this.setState({
        docExportModalWait:true
      });
      
      let selectedProjectId = localStorage.getItem('selectedProjectId');
      let selectedModelId = localStorage.getItem('selectedModelId');            
      

      let projectList = JSON.parse(localStorage.getItem('projectList'));
      let projectName = projectList[0].title;
      let modalName = projectList[0].children[0].title;

      if(fileType==='excel'){
        let fileName = projectName+'_'+modalName+'cost_data.xlsx';
        let costData = await axios.get(
          '/api/function/animation/exportCSV/' +
          selectedProjectId + '/' + selectedModelId + '/' + fileType + '/' + downloadOption,
          {responseType:'arraybuffer'}
        );      

        let file = new Blob([costData.data],{type:'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'});

        FileSaver.saveAs(file,fileName);
      }      
      else if(fileType==='pdf'){
        let fileName = projectName+'_'+modalName+'cost_data.pdf';
        let costData = await axios.get(
          '/api/function/animation/exportCSV/' +
          selectedProjectId + '/' + selectedModelId + '/' + fileType + '/' + downloadOption,
          {responseType:'blob'}
        );      

        let file = new Blob([costData.data],{type:'application/pdf'});

        FileSaver.saveAs(file,fileName);        
      }
      else {
        return
      }
      // closing the modal
      this.setState({        
        docExportModalState:false
      });
    } 
    else {      
      this.setState({
        docExportModalWait:false,
        docExportModalState:true
      });
    }    
  }

  render() {
    return (
      <>
        {/* select projects and please wait for dynamos modal - front elements */}
        <Modal isOpen={this.state.modalState} style={modalStyles}>
          <img src={closeIcon} style={modalStyles.img} 
            onClick={()=>this.setState({modalState:false})}/>
          <h2 style={modalStyles.h2}>{this.state.modalText}</h2>
        </Modal> 
        {/* Document export modal*/}
        <button onClick={this.testing}>testing</button>
        <Modal isOpen={this.state.docExportModalState} style={docExportModalStyles}>
          {
            this.state.docExportModalWait &&
            <>
              <img 
                src={closeIcon} style={docExportModalStyles.img}
                onClick={()=>this.setState({docExportModalState:false})}
              />
              <h1>Please wait</h1>
            </>
          }
          {
            !this.state.docExportModalWait &&
            <>
              <img 
                src={closeIcon} style={docExportModalStyles.img}
                onClick={()=>this.setState({docExportModalState:false})}
              />
              <div style={{display:'flex'}}>            
                <Radio.Group 
                  onChange={e=>this.setState({docExportModalRadioValue:e.target.value})} 
                  value={this.state.docExportModalRadioValue}
                >
                  <Radio value='category'>Category</Radio>
                  <Radio value='full'>Full</Radio>              
                </Radio.Group>
              </div>          
              <div>            
                <button
                  style={docExportModalStyles.button}
                  onClick={()=>this.testing('pdf')}
                >
                  Export as pdf
                </button>
                <button 
                  style={docExportModalStyles.button}
                  onClick={()=>this.testing('excel')}
                >
                  Export as excel
                </button>            
              </div>
            </>
          }          
        </Modal>                
        <Split
          ref={this.split1}
          minSize={[600, 0]}
          sizes={[60, 40]}
          gutterSize={5}
          gutterAlign="center"
          direction="horizontal"
          cursor="col-resize"
          style={{
            position: 'fixed',
            height: `100%`,
            width: '100%',
            display: 'flex',
            justifyItems: 'center',
            alignItems: 'center',
            borderTop: '2px #d8d8d8 solid',
          }}
          onDrag={this.dragSplit}
        >
          <div id="content3D" style={{ height: '100%', width: '100%' }}>
            <div
              style={{
                float: 'left',
                zIndex: 100,
                marginLeft: '10px',
              }}
              className=" flex flex-col space-y-1"
            >
              <img
                title="Expand"
                src="/img/menu1.png"
                class="img__icon__content3D"
                onClick={() => {
                  this.handleExpandMainViewer.bind(this);
                  this.setState({
                    isExpandMenuLeft: !this.state.isExpandMenuLeft,
                  });
                }}
              />

              {this.state.isExpandMenuLeft && [
                <img
                  title="Projects"
                  src="/img/project2.png"
                  id="project2Png"
                  class="img__icon__content3D"
                  onClick={() => this.setState({ projectListVisible: true })}
                />,
                <img
                  title="Reports"
                  src="/img/clash.png"
                  class="img__icon__content3D"
                  onClick={this.handleExpandMainViewer.bind(this)}
                />,
                <img
                  title="Clashes"
                  src="/img/i2.png"
                  id="iPng"
                  class="img__icon__content3D"
                  onClick={this.handleExpandMainViewer.bind(this)}
                />,
              ]}

              <img></img>
            </div>

            <Button
              style={{ float: 'right', zIndex: 100 }}
              type="primary"
              onClick={this.handleExpandMainViewer.bind(this)}
              icon={
                this.state.isCollapse ? <RightOutlined /> : <LeftOutlined />
              }
            />
            <div
              id="forgeViewer"
              style={{
                position: 'relative',
                height: '100%',
                width: '100%',
              }}
            >
              <div
                className="progress"
                style={{
                  zIndex: 100,
                  position: 'absolute',
                  width: '100%',
                  display: 'none',
                }}
              >
                <div
                  id="animation-status"
                  className="progress-bar"
                  role="progressbar"
                  style={{ width: '0%' }}
                  aria-valuenow="25"
                  aria-valuemin="0"
                  aria-valuemax="100"
                >
                  0%
                </div>
              </div>
              {/* <button onClick={this.testing}>Testing</button> */}
              <PercentageCircle
                percentScore={this.props.percent}
                selectedProjectId={this.state.selectedProjectId}
                // call to child to open the score model
                shouldOpen={this.state.percentageCircleState}
                // percentage circle state handler - to call from child
                percentageCircleStateHandler={this.percentageCircleStateHandler}
                AIWaitModalHandler={this.AIWaitModalHandler}
                style={{
                  zIndex: 101,
                  position: 'absolute',
                  width: 100,
                  bottom: 120,
                  right: 10,
                  whiteSpace: 'break-spaces',
                }}
              />
            </div>
          </div>
          <Split
            minSize={[40, 40, 40, 40]}
            ref={this.split2}
            sizes={[1, 97, 1, 1]}
            gutterSize={5}
            gutterAlign="center"
            direction="vertical"
            cursor="col-resize"
            style={{
              height: `100%`,
              width: '100%',
              justifyItems: 'center',
              alignItems: 'center',
              borderTop: '2px #d8d8d8 solid',
            }}
            onDrag={this.dragSplit1}
          >
            <div
              style={{
                position: 'relative',
                height: '100%',
                width: '100%',
              }}
            >
              <div
                style={{
                  height: 40,
                  width: '100%',
                  backgroundColor: '#ebebeb',
                  borderBottom: '1px solid gray',
                  borderTop: '1px solid gray',
                  padding: 2,
                }}
                className="flex flex-row justify-between items-center"
              >
                <Text
                  onClick={() => {
                    this.handleExpand(0);
                    this.setState({ indexExpand: 0 });
                  }}
                  strong
                  style={{
                    marginLeft: 5,
                    textDecoration: 'underline',
                    cursor: 'pointer',
                  }}
                >
                  View 2D
                </Text>
                <Button
                  ghost
                  type="primary"
                  onClick={() => {
                    this.handleExpand(0);
                    this.setState({ indexExpand: 0 });
                  }}
                  icon={<ExpandAltOutlined />}
                />
              </div>
              <div
                id="forgeViewer2D"
                style={{
                  position: 'relative',
                  height: 'calc(100% - 40px)',
                  width: '100%',
                }}
              />
            </div>

            <div ref={this.tableRef} style={{ height: '100%', width: '100%' }}>
              <div
                style={{
                  height: 40,
                  width: '100%',
                  backgroundColor: '#ebebeb',
                  borderBottom: '1px solid gray',
                  borderTop: '1px solid gray',
                  padding: 2,
                }}
              >
                {/* <Text strong style={{ marginLeft: 5, top: "51%" }}>
            
                </Text> */}

                <Select
                  defaultValue={this.state.selectedTableType}
                  style={{ width: 200, marginLeft: 5 }}
                  onChange={(e) => this.setState({ selectedTableType: e })}
                >
                  <Option value="material">Table Material</Option>
                  <Option value="category">Table Category</Option>
                  <Option value="assembly">Table Assembly</Option>
                </Select>

                <Button
                  ghost
                  style={{ marginLeft: 5 }}
                  type="primary"
                  onClick={this.handleLoadMaterial.bind(this)}
                  icon={<ReloadOutlined />}
                />

                <Button
                  style={{ float: 'right' }}
                  ghost
                  type="primary"
                  onClick={() => {
                    this.handleExpand(1);
                    this.setState({ indexExpand: 1 });
                  }}
                  icon={<ExpandAltOutlined />}
                />
              </div>
              <div
                id="table-material"
                style={{ height: 'calc(100% - 40px)', width: '100%' }}
              >
                {
                  <TableMaterial
                    heightTable={this.state.heightTable}
                    widthTable={this.state.widthTable}
                    data={this.state.dataTable}
                    load={this.state.loadTableMaterial}
                    viewer={this.state.viewer}
                    selectedTableType={this.state.selectedTableType}
                    missingAssemblyCodeHandler={this.MissingAssemblyCodeHandler}
                  />
                }
              </div>
            </div>

            <div style={{ height: '100%', width: '100%' }}>
              <div
                style={{
                  height: 40,
                  width: '100%',
                  backgroundColor: '#ebebeb',
                  borderBottom: '1px solid gray',
                  borderTop: '1px solid gray',
                  padding: 2,
                }}
              >
                <Text
                  strong
                  style={{
                    marginLeft: 5,
                    top: '51%',
                    textDecoration: 'underline',
                    cursor: 'pointer',
                  }}
                  onClick={() => {
                    this.handleExpand(2);
                    this.setState({ indexExpand: 2 });
                  }}
                >
                  Cost BreakDown
                </Text>
                <Select
                  defaultValue={this.state.selectedCategory}
                  style={{ width: 120, marginLeft: 5 }}
                  onChange={this.handleChangeCategory.bind(this)}
                >
                  <Option value="material">Material</Option>
                  <Option value="category">Category</Option>
                  <Option value="level">Level</Option>
                </Select>
                <Button
                  style={{ float: 'right' }}
                  ghost
                  type="primary"
                  onClick={() => {
                    this.handleExpand(2);
                    this.setState({ indexExpand: 2 });
                  }}
                  icon={<ExpandAltOutlined />}
                />
              </div>
              <p style={{ color: 'white' }}>{this.state.indexExpand}</p>
              {this.state.indexExpand === 2 && (
                <PieChart
                  data={
                    this.state.selectedCategory === 'material'
                      ? this.state.dataPieChart
                      : this.state.selectedCategory === 'category'
                      ? this.state.dataCategoryPieChart
                      : this.state.dataLevelPieChart
                  }
                  viewer={this.state.viewer}
                />
              )}
            </div>

            <div ref={this.tableRef} style={{ height: '100%', width: '100%' }}>
              <div
                style={{
                  height: 40,
                  width: '100%',
                  backgroundColor: '#ebebeb',
                  borderBottom: '1px solid gray',
                  borderTop: '1px solid gray',
                  padding: 2,
                }}
              >
                <Text
                  strong
                  style={{
                    marginLeft: 5,
                    top: '51%',
                    textDecoration: 'underline',
                    cursor: 'pointer',
                  }}
                  onClick={() => {
                    this.handleExpand(3);
                    this.setState({ indexExpand: 3 });
                  }}
                  className="font-bold"
                >
                  Table Assembly Code
                </Text>

                <Button
                  style={{ marginLeft: '5px' }}
                  ghost
                  type="primary"
                  onClick={this.handleLoadAssemblyCode.bind(this)}
                  icon={<ReloadOutlined />}
                />
                <Button
                  style={{ float: 'right' }}
                  ghost
                  type="primary"
                  onClick={() => {
                    this.handleExpand(3);
                    this.setState({ indexExpand: 3 });
                  }}
                  icon={<ExpandAltOutlined />}
                />
              </div>
              <div
                id="table-material"
                style={{ height: 'calc(100% - 120px)', width: '100%' }}
              >
                {
                  <TableAssemblyCode
                    heightTable={this.state.heightTable}
                    widthTable={this.state.widthTable}
                    load={this.state.loadTableAssemblyCode}
                    viewer={this.state.viewer}
                  />
                }
              </div>
            </div>
          </Split>
        </Split>
        <Toaster
          ref={this.toaster}
          position={Position.TOP}
          canEscapeKeyClear={false}
        />
        <Drawer
          title="Project List"
          placement="left"
          width={500}
          onClose={() => this.setState({ projectListVisible: false })}
          visible={this.state.projectListVisible}
        >
          <p>Choose model to open</p>

          <DirectoryTree
            multiple
            defaultExpandAll
            onSelect={(e, ee) => this.onSelect(e, ee)}
            treeData={this.state.projectList}
          />

          <p className="mt-2">Add New File</p>

          <Box
            className=" mt-3"
            display="flex"
            justifyContent="center"
            alignItems="center"
          >
            <div style={{ width: '100%' }}>
              <div style={{ width: '100%', margin: 'auto' }}>
                <Dragger
                  className="checkbox-tools"
                  multiple={true}
                  beforeUpload={this.beforeUpload}
                  accept=" "
                  showUploadList={true}
                >
                  <p className="ant-upload-drag-icon">
                    <InboxOutlined />
                  </p>
                  <p className="ant-upload-text">
                    Click or drag revit file to this area to upload
                  </p>
                </Dragger>
                <Progress percent={this.state.percent} status="active" />
                Tranlating Progress : {this.state.percentStatus}
                <Button
                  className="mt-2"
                  type="primary"
                  block
                  onClick={this.handleUploadFile}
                >
                  Submit
                </Button>
                <Button
                  className="mt-2"
                  type="primary"
                  block
                  onClick={() => {
                    this.props.history.push(``);
                  }}
                >
                  Create New Project
                </Button>
               
              </div>
            </div>
          </Box>
        </Drawer>
        <Drawer
          title="Project List"
          placement="left"
          width={500}
          onClose={() => this.setState({ clashVisible: false })}
          visible={this.state.clashVisible}
        >
          <p>Clash Raw Data</p>
        </Drawer>
        {this.props.compairDialog && (
          <DialogCompare3D
            openPanel={this.props.compairDialog}
            viewer={this.state.viewer2D}
            viewer3d={this.state.viewer}
            onChangeDisplay={() => {}}
            itemId={null}
            id={null}
            selectedModel={this.state.selectedModel}
            onChangeDisplayComparisonModel={() => {}}
            heightNavigation={200}
            models={this.getModelsForCompare()}
            closeDialogCompare={() =>
              window.store.dispatch({
                type: 'COMPAIR',
                payload: false,
              })
            }
          />
        )}
      </>
    );
  }
}

function mapStateToProps(state) {
  console.log('state.counter', state.counter);
  return {
    count: state.counter.count,
    percent: state.counter.percent,
    compairDialog: state.counter.compairDialog,
  };
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators(
    {
      handleIncrease: increaseCount,
      handleDecrease: decreaseCount,
      handleReset: resetCount,
      handleSetCompairDialog: compair,
    },
    dispatch
  );
}

export default connect(mapStateToProps, mapDispatchToProps)(ForgeViewerProject);
