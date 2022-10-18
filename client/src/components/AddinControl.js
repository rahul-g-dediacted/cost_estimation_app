import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import axios from 'axios';
import { Progress, Dropdown, Header } from 'semantic-ui-react';
import $ from 'jquery';
import _ from 'lodash';
import { Loader } from 'rsuite';
import { message, Row, Col, Card, Empty, List, Tag, Button } from 'antd';
class AddinControl extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      listEngines: [],
      listAppBundle: [],
      fileName: null,
      engine: null,
      statusText: 'Status',
      disableCreateBtn: false,
      disableDeleteBtn: false,
      progressBarStatus: 0,

      listtActivities: [],
      loading: false,
    };
  }

  componentWillMount = () => {
    this.setState({ loading: true });
    axios
      .get('/api/forge/designautomation/engines')
      .then((res) => {
        let temp = [];
        _.forEach(res.data, (v, k) => {
          temp.push({ key: k, text: v, value: v });
        });
        this.setState({ listEngines: temp });
      })
      .catch((err) => {});

    axios
      .get('/api/forge/appbundles')
      .then((res) => {
        let temp = [];
        _.forEach(res.data, (v, k) => {
          temp.push({ key: k, text: v, value: v });
        });
        this.setState({ listAppBundle: temp });
      })
      .catch((err) => {});

    axios
      .get('/api/forge/designautomation/list-activities')
      .then((res) => {
        this.setState({ listtActivities: res.data, loading: false });
      })
      .catch((err) => {
        message.error('Failed to get activities.');
        this.setState({ loading: false });
      });
  };

  handleClosePanel = () => {
    this.setState({ progressBarStatus: 0 });
    this.props.closeDialogConfigure(false);
  };

  deleteAppBundleActivity = async (name, e) => {
    e.preventDefault();

    const zipFileName = name;
    const fileName = zipFileName.slice(0, zipFileName.length - 8);
    const activityName = fileName + 'Activity';
    const appBundleName = fileName + 'AppBundle';

    if (
      !window.confirm(
        'Are you sure you want to delete the AppBundle & Activity for this zip Package?'
      )
    )
      return;
    this.setState({ loading: true });
    try {
      this.updateConfigStatus('deleting_appbundle', appBundleName);
      await this.deleteAppBundle(appBundleName);

      this.updateConfigStatus('deleting_activity', activityName);
      await this.deleteActivity(activityName);

      this.updateConfigStatus(
        'deleting_completed',
        `${appBundleName} & ${activityName}`
      );
    } catch (err) {
      console.log(err);
      this.updateConfigStatus(
        'deleting_failed',
        `${appBundleName} & ${activityName}`
      );
    }
  };
  deleteAppBundle = async (appBundleName) => {
    let def = $.Deferred();

    $.ajax({
      url:
        '/api/forge/designautomation/appbundles/' +
        encodeURIComponent(appBundleName),
      type: 'delete',
      dataType: 'json',
      success: function (res) {
        def.resolve(res);
      },
      error: function (err) {
        def.reject(err);
        message.error(err.data);
      },
    });
    return def.promise();
  };
  deleteActivity = async (activityName) => {
    let def = $.Deferred();

    $.ajax({
      url:
        '/api/forge/designautomation/activities/' +
        encodeURIComponent(activityName),
      type: 'delete',
      dataType: 'json',
      success: function (res) {
        def.resolve(res);
      },
      error: function (err) {
        def.reject(err);
        message.error(err.data);
      },
    });

    return def.promise();
  };
  createAppBundleActivity = async () => {
    if (this.state.fileName === null) message.warn('Please pick add-in');
    else if (this.state.engine === null) message.warn('Please pick engine');
    else if (this.state.fileName !== null && this.state.engine !== null) {
      const fileName = this.state.fileName.split('.')[0];

      let file = fileName.split('_');
      let engine = this.state.engine.split('+');
      if (file[file.length - 1] === engine[engine.length - 1]) {
        try {
          this.updateConfigStatus('creating_appbundle', fileName + 'AppBundle');
          const appBundle = await this.createAppBundle(fileName);

          this.updateConfigStatus('creating_activity', fileName + 'Activity');
          const activity = await this.createActivity(fileName);

          this.updateConfigStatus(
            'creating_completed',
            `${fileName}AppBundle & ${fileName}Activity`
          );
        } catch (err) {
          this.updateConfigStatus(
            'creating_failed',
            `${fileName}AppBundle & ${fileName}Activity`
          );
          console.log('Failed to create AppBundle and Activity.');
          return;
        }
      } else {
        message.warn('Re-pick engine');
      }
    }
  };
  createAppBundle = (fileName) => {
    let def = $.Deferred();
    let _this = this;
    $.ajax({
      url: 'api/forge/designautomation/appbundles',
      method: 'POST',
      contentType: 'application/json',
      dataType: 'json',
      data: JSON.stringify({
        fileName: fileName,
        engine: this.state.engine,
      }),
      success: function (res) {
        def.resolve(res);
        // _this.setState({fileName:null, engine:null})
      },
      error: function (err) {
        def.reject(err);
        message.error(err.data);
        // _this.setState({fileName:null, engine:null})
      },
    });
    return def.promise();
  };
  createActivity = (fileName) => {
    let def = $.Deferred();

    $.ajax({
      url: 'api/forge/designautomation/activities',
      method: 'POST',
      contentType: 'application/json',
      dataType: 'json',
      data: JSON.stringify({
        fileName: fileName,
        engine: this.state.engine,
      }),
      success: function (res) {
        def.resolve(res);
      },
      error: function (err) {
        console.log(err);
        message.error(err.data);
        def.reject(err);
      },
    });
    return def.promise();
  };
  updateConfigStatus = (status, info = '') => {
    switch (status) {
      case 'creating_appbundle':
        this.setState({
          progressBarStatus: 20,
          statusText: 'Step 1/2: Creating AppBundle: ' + info,
          disableCreateBtn: true,
          disableDeleteBtn: true,
        });
        break;
      case 'creating_activity':
        this.setState({
          progressBarStatus: 60,
          statusText: 'Step 2/2: Creating Activity: ' + info,
          disableCreateBtn: true,
          disableDeleteBtn: true,
        });
        break;
      case 'creating_completed':
        this.setState({
          progressBarStatus: 100,
          statusText: 'Created:\n' + info,
          disableCreateBtn: false,
          disableDeleteBtn: false,
        });
        axios
          .get('/api/forge/designautomation/list-activities')
          .then((res) => {
            this.setState({ listtActivities: res.data, loading: false });
          })
          .catch((err) => {
            message.error('Failed to get activities.');
            this.setState({ loading: false });
          });
        break;

      case 'creating_failed':
        this.setState({
          progressBarStatus: 0,
          statusText: 'Failed to create:\n' + info,
          disableCreateBtn: false,
          disableDeleteBtn: false,
        });
        break;

      case 'deleting_appbundle':
        this.setState({
          progressBarStatus: 20,
          statusText: 'Step 1/2: Deleting AppBundle: ' + info,
          disableCreateBtn: true,
          disableDeleteBtn: true,
        });
        break;
      case 'deleting_activity':
        this.setState({
          progressBarStatus: 60,
          statusText: 'Step 2/2: Deleting Activity: ' + info,
          disableCreateBtn: true,
          disableDeleteBtn: true,
        });
        break;
      case 'deleting_completed':
        this.setState({
          progressBarStatus: 100,
          statusText: 'Deleted:\n' + info,
          disableCreateBtn: false,
          disableDeleteBtn: false,
        });
        axios
          .get('/api/forge/designautomation/list-activities')
          .then((res) => {
            this.setState({ listtActivities: res.data, loading: false });
          })
          .catch((err) => {
            message.error('Failed to get activities.');
            this.setState({ loading: false });
          });
        break;
      case 'deleting_failed':
        this.setState({
          progressBarStatus: 0,
          statusText: 'Failed to delete:\n' + info,
          disableCreateBtn: false,
          disableDeleteBtn: false,
        });
        break;
    }
  };

  //?
  onChangeFileName = (e, data) => {
    this.setState({ fileName: data.value });
  };
  onChangeEngine = (e, data) => {
    this.setState({ engine: data.value });
  };

  //!

  render() {
    return (
      <div style={{ height: '100%' }}>
        <Row style={{ height: '100%' }}>
          <Col span={12} style={{ height: 'calc(100vh - 30px' }}>
            <Card
              type='inner'
              style={{
                height: '100%',
                margin: 15,
                overflow: 'auto',
                boxShadow: '3px 4px 13px 0px #bab2b2',
              }}
            >
              <div class='alert alert-warning'>
                <center>
                  Define AppBundle &amp; Activity only once.
                  <br />
                  Redefine only when your plugin code change (creates a new
                  version).
                </center>
              </div>
              <div class='form-group'>
                <label for='localBundles'>Select a local AppBundle:</label>
                <Dropdown
                  onChange={this.onChangeFileName}
                  placeholder='AppBundle'
                  fluid
                  selection
                  options={this.state.listAppBundle}
                />
                <b>Tip:</b> Make sure .ZIP bundles are placed at{' '}
                <b>/bundles/</b> folder
              </div>
              <div class='form-group'>
                <label for='engines'>Select engine:</label>
                <Dropdown
                  onChange={this.onChangeEngine}
                  placeholder='engines'
                  fluid
                  selection
                  options={this.state.listEngines}
                />
              </div>
              {this.state.progressBarStatus > 0 && (
                <div>
                  <Header as='h3'>{this.state.statusText}</Header>
                  <Progress
                    style={{ height: 25 }}
                    id='configProgressBar'
                    percent={this.state.progressBarStatus}
                    indicating
                  />
                </div>
              )}
              <div style={{ right: 20, bottom: 20}}>
                <Button
                  type='primary'
                  onClick={this.createAppBundleActivity}
                  disabled={this.state.disableCreateBtn}
                >
                  Create/Update
                </Button>
                {/* <Button onClick={this.deleteAppBundleActivity} color="red" disabled={this.state.disableDeleteBtn}>
                  Delete
            </Button> */}
              </div>
            </Card>
          </Col>
          <Col span={12} style={{ height: 'calc(100% - 30px' }}>
            <Card
              type='inner'
              style={{
                height: '100%',
                margin: 15,
                overflow: 'auto',
                boxShadow: '3px 4px 13px 0px #bab2b2',
              }}
            >
              {this.state.loading ? (
                <Loader
                  backdrop
                  center
                  content='Loading...'
                  speed='fast'
                  size='md'
                  vertical
                />
              ) : this.state.listtActivities.length === 0 ? (
                <Empty />
              ) : (
                <List>
                  {this.state.listtActivities.map((item) => (
                    <List.Item>
                      <Tag
                        closable
                        onClose={this.deleteAppBundleActivity.bind(this, item)}
                        color='magenta'
                      >
                        {item}
                      </Tag>
                    </List.Item>
                  ))}
                </List>
              )}
            </Card>
          </Col>
        </Row>
      </div>
    );
  }
}


export default AddinControl;
