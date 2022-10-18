import React from 'react';
import { Dropdown, Divider, Input, Checkbox, Header } from 'semantic-ui-react';
import { Modal, SelectPicker, Button, IconButton, Icon, Loader } from 'rsuite';
import _ from 'lodash';
import axios from 'axios';
import $ from 'jquery';
import { message } from 'antd';

import moment from 'moment';

const THREE = window.THREE;
const Autodesk = window.Autodesk;

class DialogCompare extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      openPanel: true,
      openPanelListViewable: false,
      listVersion: [],
      defaultId: null,
      versionCompareId: null,
      listViewable: [],
      viewableCurrent: null,
      viewableSelected: null,
      displayTableCompare: false,
      lodingBtnVersion: false,
      loadingBtnCompare: false,
      loading: false,
      secondModelname: '',
    };
  }

  getListVersion() {
    if (this.props.models && _.isArray(this.props.models)) {
      let ar = this.props.models.map((x) => ({
        ...x,
        key: x.id,
        text: x.modelName,
        value: x.id,
      }));
      return ar;
    }

    return [];
  }

  componentWillMount = () => {
    console.log('mount', this.props.selectedModel);
    this.setState({ loading: true });
    let optionVersion = [];
    let defaultId = '';
    console.log('this.props.models', this.props.models);
    _.forEach(this.props.models, (item) => {
      let split = item.objectKey.split('-')[0];
      let name = item.objectKey.replace(split + '-', '');
      if (this.props.id === item.objectId)
        defaultId = name + '-v' + item.version;
      else
        optionVersion.push({
          key: item.objectId,
          text: name + '-v' + item.version,
          value: { id: item.objectId, name: name + '-v' + item.version },
        });
    });
    this.setState({
      listVersion: optionVersion,
      defaultId: defaultId,
      loading: false,
      openPanel: true,
    });
  };

  handleClosePanel = () => {
    this.setState({ openPanel: false, versionCompareId: null });
    this.props.closeDialogCompare();
  };

  handleChangeVersion = (e, { value, text }) => {
    console.log('value', value);
    this.setState({ versionCompareId: value, secondModelname: text });
  };

  handleSelectViewable = () => {
    console.log('this.state.versionCompareId', this.state.versionCompareId);
    this.setState({ lodingBtnVersion: true });
    const models = this.props.viewer.impl.modelQueue().getModels();
    if (models.length === 1) {
      Autodesk.Viewing.Document.load(
        'urn:' + this.state.versionCompareId,
        this._onDocumentLoadSuccess,
        this._onDocumentLoadFailure
      );
    } else {
      message.warning('Please remove other models');
    }
  };
  _onDocumentLoadFailure = (viewerErrorCode) => {};
  _onDocumentLoadSuccess = (doc) => {
    let temp = [];
    console.log(
      'this.props.viewer.impl.model.is3d()',
      this.props.viewer.impl.model.is3d()
    );
    let views = doc.getRoot().search({ type: 'geometry', role: '2d' }, true);
    let guidMain = this.props.viewer.impl.model.getDocumentNode().data.guid;
    let viewableSelected = null;
    _.forEach(views, (v) => {
      if (v.data.guid === guidMain) viewableSelected = v;
      temp.push({
        label: v.data.name,
        value: v.data.guid,
        group: v.data.role.toUpperCase(),
        obj: v,
      });
    });
    this.setState({
      listViewable: temp,
      document: doc,
      openPanelListViewable: true,
      versionCompareId: null,
      openPanel: false,
      viewableCurrent: guidMain,
      viewableSelected: viewableSelected,
      lodingBtnVersion: false,
    });
    // this.props.onChangeDisplay('dialogCompare', false)
  };

  handleClosePanelListViewable = () => {
    this.setState({ openPanelListViewable: false, viewableSelected: null });
    window.store.dispatch({
      type: 'COMPAIR',
      payload: false,
    });

  };
  handleChangeView = (value, e) => {
    _.forEach(this.state.listViewable, (v) => {
      if (v.value === value) {
        this.setState({ viewableSelected: v.obj });
        return false;
      }
    });
  };
  handleCompareVersion = () => {
    this.setState({ loadingBtnCompare: true });
    let svfUrl = this.state.document.getViewablePath(
      this.state.viewableSelected
    );
    let loadOptions = {
      globalOffset: this.props.viewer.impl.model.myData.globalOffset,
      // applyRefPoint: true,
      modelNameOverride: this.state.secondModelname,
      isAEC: true,
      guid: this.state.viewableSelected.data.guid,
      acmSessionId: this.state.document.acmSessionId,
    };
    if (this.props.viewer.impl.model.is2d() || true)
      loadOptions = {
        modelNameOverride: this.state.secondModelname,
        isAEC: true,
        guid: this.state.viewableSelected.data.guid,
      };
    this.props.viewer.loadModel(
      svfUrl,
      loadOptions,
      this._onLoadModelSuccess,
      this._onLoadModelError
    );
  };
  _onLoadModelSuccess = (modelCurrent) => {
    let models = this.props.viewer.impl.modelQueue().getModels();
    _.forEach(models, (model) => {
      this.props.viewer.clearThemingColors(model);
    });
    let isAllLoaded = this.props.viewer.isLoadDone({ onlyModels: models });
    if (isAllLoaded) {
      this.compareFile(models);
    } else {
      this.props.viewer.waitForLoadDone({ onlyModels: models }).then((res) => {
        this.compareFile(models);
      });
    }
    this.setState({
      openPanelListViewable: false,
      viewableSelected: null,
      listViewable: [],
      viewableCurrent: null,
    });
    $('#btn-docbrowser').hide();
  };
  _onLoadModelError = (viewerErrorCode) => {
    this.setState({
      openPanelListViewable: false,
      viewableSelected: null,
      listViewable: [],
      viewableCurrent: null,
    });
    $('#btn-docbrowser').show();
    message.error('Comparison was failed');
  };

  compareFile = async (models) => {
    if (models.length === 2) {
      if (this.props.viewer.impl.model.is2d() || true) {
        const pcExt = await this.props.viewer.loadExtension(
          'Autodesk.Viewing.PixelCompare'
        );

        pcExt.compareTwoModels(
          this.props.viewer.getAllModels()[0],
          this.props.viewer.getAllModels()[1],
          { title: this.state.defaultId },
          { title: this.state.secondModelname }
        );
        this.setState({ loadingBtnCompare: false });
      }
    }
  };

  //#region  // ?general
  handleCloseCompareVersion = () => {
    const models = this.props.viewer.impl.modelQueue().getModels();
    this.props.viewer.clearThemingColors(this.props.viewer.impl.model);
    this.props.viewer.showAll();
    if (this.props.viewer.impl.model.is2d()) {
      this.props.viewer.unloadExtension('Autodesk.Viewing.PixelCompare');
    } else {
      this.props.viewer.unloadExtension('Autodesk.DiffTool');
      this.props.onChangeDisplay('dialogCompare', false);
      this.props.viewer.unloadModel(models[1]);
      $('#btn-docbrowser').show();
    }
  };

  //#endregion

  render() {
    return (
      <div>
        <Modal
          show={this.state.openPanel}
          onHide={this.handleClosePanel.bind(this)}
          style={{ paddingTop: '3%' }}
          backdrop="static"
        >
          <Modal.Header>
            <Modal.Title>Compare Version</Modal.Title>
          </Modal.Header>
          <Modal.Body id="modalBodyCompareVersion">
            {this.state.loading && (
              <Loader
                backdrop
                center
                content="Loading..."
                speed="fast"
                size="md"
                vertical
              />
            )}
            <Input
              value={this.props.selectedModel?.original?.modelName}
              style={{ width: '100%' }}
              disabled={true}
            />
            <Divider horizontal>VS</Divider>
            <Dropdown
              placeholder="Select Version"
              fluid
              selection
              onChange={this.handleChangeVersion}
              options={this.getListVersion()}
            />
          </Modal.Body>
          <Modal.Footer>
            <Button
              color="blue"
              onClick={this.handleSelectViewable}
              disabled={this.state.versionCompareId === null}
              loading={this.state.lodingBtnVersion}
            >
              Apply
            </Button>
            <Button
              onClick={this.handleClosePanel.bind(this)}
              appearance="subtle"
            >
              Cancel
            </Button>
          </Modal.Footer>
        </Modal>
        <Modal
          show={this.state.openPanelListViewable}
          onHide={this.handleClosePanelListViewable.bind(this)}
          size="xs"
          overflow={true}
          backdrop="static"
        >
          <Modal.Header>
            <Modal.Title>List Viewables</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <SelectPicker
              data={this.state.listViewable}
              style={{ width: '100%' }}
              defaultValue={this.state.viewableCurrent}
              groupBy="group"
              placeholder="Select View"
              cleanable={false}
              onChange={this.handleChangeView}
              renderMenuItem={(label, item) => {
                return (
                  <div>
                    <i
                      className={
                        item.group === '3D'
                          ? 'rs-icon rs-icon-coincide'
                          : 'rs-icon rs-icon-newspaper-o'
                      }
                    />{' '}
                    {label}
                  </div>
                );
              }}
              renderMenuGroup={(label, item) => {
                return (
                  <div>
                    <i
                      className={
                        label === '3D'
                          ? 'rs-icon rs-icon-coincide'
                          : 'rs-icon rs-icon-newspaper-o'
                      }
                    />{' '}
                    {label} - ({item.children.length})
                  </div>
                );
              }}
              renderValue={(value, item) => {
                console.log('itwm', item);
                return (
                  <div>
                    {/* <span style={{ color: "#000000" }}>
                      <i
                        className={
                          item.group === "3D"
                            ? "rs-icon rs-icon-coincide"
                            : "rs-icon rs-icon-newspaper-o"
                        }
                      />
                      {item.group === "3D" ? " View3D" : " Sheet"} :
                    </span>{" "} */}
                    {item?.label}
                  </div>
                );
              }}
            />
          </Modal.Body>
          <Modal.Footer>
            <Button
              onClick={this.close}
              onClick={this.handleCompareVersion.bind(this)}
              appearance="primary"
              disabled={this.state.viewableSelected === null}
              loading={this.state.loadingBtnCompare}
            >
              Compare
            </Button>
            <Button
              onClick={this.close}
              onClick={this.handleClosePanelListViewable.bind(this)}
              appearance="subtle"
            >
              Cancel
            </Button>
          </Modal.Footer>
        </Modal>

        {this.state.displayTableCompare && (
          <IconButton
            style={{
              zIndex: '10',
              float: 'right',
              backgroundColor: 'red',
              top: '0',
              color: 'white',
            }}
            size="sm"
            onClick={this.handleCloseCompareVersion}
            icon={<Icon icon="close" />}
          ></IconButton>
        )}
      </div>
    );
  }
}

export default DialogCompare;
