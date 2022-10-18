import React from 'react';
import axios from 'axios';
import { Upload, message, Button, notification } from 'antd';
import { InboxOutlined } from '@ant-design/icons';
import { Container, Box } from '@material-ui/core';
import { socket } from '../functions/AutodeskForge';
import { Layout } from 'antd';
import { Row, Col, Divider, Progress, InputNumber } from 'antd';
import { Radio } from 'antd';
import LoadingOverlay from 'react-loading-overlay';

const { Header, Footer, Sider, Content } = Layout;
const { Dragger } = Upload;

let projectId = '';
let modelData = {};

class ForgeUpload extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isOverlay: false,
      percent: 'Uploading model',
      loading: false,
      file: [],
      laborTypes: [
        {
          value: 'std',
          description: 'Standard Union',
        },
        {
          value: 'opn',
          description: 'Non Union',
        },
        {
          value: 'res',
          description: 'Residential',
        },
        {
          value: 'fed',
          description: 'Federal',
        },
        {
          value: 'he',
          description: 'Higher Education',
        },
      ],
      projectTypes: [
        {
          description: 'RESIDENTIAL',
          value: 'RESIDENTIAL',
        },
        {
          description: 'COMMERCIAL',
          value: 'COMMERCIAL',
        },
        {
          description: 'INDUSTRIAL',
          value: 'INDUSTRIAL',
        },
        {
          description: 'GREEN BUILDING',
          value: 'GREEN BUILDING',
        },
        {
          description: 'CIVIL / HEAVY CONSTRUCTION',
          value: 'CIVIL / HEAVY CONSTRUCTION',
        },
      ],
      projectRequest: {
        ProjectName: null,
        LarborType: 'std',
        ProjectType: '',
        ZipCode: '',
      },
      percent: 0,
      showRequireProject: false,
    };
    this.toaster = React.createRef();
  }
  componentWillMount = () => {
    socket.on('realtime-upload', this.realtimeUpload);
    socket.on('realtime-translate', this.realtimeTranslate);
    socket.on('realtime-translate-process', this.realtimeTranslateProgress);
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
    this.setState({ percent: 'Translating model ' + data.progress + ' %' });
  };
  realtimeTranslate = (data) => {
    this.setState({ loading: false });
    message.success('Translate file was success');

    // truin changes
    localStorage.setItem('projectType', this.state.projectRequest.ProjectType);
    localStorage.setItem('laborType', this.state.projectRequest.LarborType);
    localStorage.setItem('zipCode', this.state.projectRequest.ZipCode);

    this.props.history.push(`project?projectId=${projectId}&&urn=${data.urn}`);
  };
  beforeUpload = (file, fileList) => {
    this.setState({ file: [...this.state.file, ...fileList] });
    return false;
  };
  handleUploadFile = async () => {
    if (
      !this.state.projectRequest.ProjectName ||
      this.state.projectRequest.ProjectName.length < 1
    ) {
      this.setState({ showRequireProject: true });
      return;
    }

    console.log('this.state.projectRequest', this.state.projectRequest);

    try {
      let res = await axios.post(
        `/api/function/animation/project-add`,
        this.state.projectRequest
      );

      this.setState({ isOverlay: true });
      projectId = res.data._id;

      if (Array.isArray(this.state.file)) {
        let i = 0;
        for (let file of this.state.file) {
          this.setState({ loading: true });
          var data = new FormData();
          data.append('fileToUpload', file);
          if (data !== undefined || data !== null) {
            axios
              .post(`/api/forge/oss/objects/` + res.data._id, data)
              .then((res) => {
                modelData = res.data;
              })
              .catch(() => {
                this.setState({ loading: false });
                message.error('Upload file was failed');
              });
          }
          i++;
        }
      }
    } catch (error) {
      this.setState({ isOverlay: false });
      notification['error']({
        message: 'Error',
        description: error.response.data.message,
      });
    }

    //add files to projects
  };

  render() {
    return (
      <>
        <LoadingOverlay
          active={this.state.isOverlay}
          spinner
          text={this.state.percent}
        >
          <Layout>
            <Header style={{ height: '80px', backgroundColor: '#77bdff' }}>
              <img
                style={{ height: '80px', backgroundColor: '#77bdff' }}
                title='Expand'
                src='logop3d.ico'
              />
            </Header>
            <Content style={{ height: 'calc(100vh - 80px)' }}>
              <div className='container mx-auto'>
                <div className='mt-5'>
                  <input
                    value={this.state.projectRequest.ProjectName}
                    onChange={(e) => {
                      this.setState({
                        projectRequest: {
                          ...this.state.projectRequest,
                          ProjectName: e.target.value,
                        },
                      });
                    }}
                    className='inputText mb-30'
                    type='text'
                    placeholder='Project Name *'
                  />
                  {this.state.showRequireProject && (
                    <label className='text-red-500'>
                      Please enter the project name
                    </label>
                  )}
                </div>

                <div className='mt-4'>
                  <lable>1. What is the type of this project?</lable>{' '}
                  <div className=' mt-3'>
                    {this.state.projectTypes.map((x) => (
                      <div
                        style={{ display: 'inline' }}
                        onClick={() => {
                          this.setState({
                            projectRequest: {
                              ...this.state.projectRequest,
                              ProjectType: x.value,
                            },
                          });
                        }}
                      >
                        <RadioBox
                          key={x.value}
                          title={x.description}
                          id={x.value}
                          name='laborProject2'
                        />
                      </div>
                    ))}
                  </div>
                </div>

                <div className='mt-4'>
                  <lable>2. What is the labor type for this project?</lable>{' '}
                  <div className=' mt-3'>
                    {this.state.laborTypes.map((x) => (
                      <div
                        style={{ display: 'inline' }}
                        onClick={() => {
                          this.setState({
                            projectRequest: {
                              ...this.state.projectRequest,
                              LarborType: x.value,
                            },
                          });
                        }}
                      >
                        <RadioBox
                          name='laborProject'
                          key={x.value}
                          title={x.description}
                          id={x.value}
                          onclick={() =>
                            this.setState({
                              projectRequest: {
                                ...this.state.projectRequest,
                                LarborType: x.value,
                              },
                            })
                          }
                        />
                      </div>
                    ))}
                  </div>
                </div>

                <div className='mt-4'>
                  <lable>3. Enter Zip Code?</lable>{' '}
                  <InputNumber
                    min={100000}
                    value={this.state.projectRequest.ZipCode}
                    onChange={(e) => {
                      this.setState({
                        projectRequest: {
                          ...this.state.projectRequest,
                          ZipCode: e,
                        },
                      });
                    }}
                    placeholder='Zip Code'
                  />
                </div>

                <div className='mt-4'>
                  <lable>Project File?</lable>{' '}
                  <Box
                    className=' mt-3'
                    display='flex'
                    justifyContent='center'
                    alignItems='center'
                  >
                    <div style={{ width: '100%' }}>
                      <div style={{ width: '100%', margin: 'auto' }}>
                        <Dragger
                          className='checkbox-tools'
                          multiple={true}
                          beforeUpload={this.beforeUpload}
                          accept=' '
                          showUploadList={true}
                        >
                          <p className='ant-upload-drag-icon'>
                            <InboxOutlined />
                          </p>
                          <p className='ant-upload-text'>
                            Click or drag revit file to this area to upload
                          </p>
                        </Dragger>

                        <Progress
                          percent={this.state.percent}
                          status='active'
                        />
                        <Button
                          loading={this.state.loading}
                          // disabled={this.state.file === null}
                          type='primary'
                          block
                          onClick={this.handleUploadFile}
                        >
                          Submit
                        </Button>
                      </div>
                    </div>
                  </Box>
                </div>
              </div>
            </Content>
          </Layout>
        </LoadingOverlay>
      </>
    );
  }
}

const RadioBox = (props) => {
  const { name, title, id } = props;
  return (
    <>
      <input className='checkbox-tools' type='radio' name={name} id={id} />
      <label className='for-checkbox-tools' for={id}>
        <i className='uil uil-line-alt'></i>
        {title}
      </label>
    </>
  );
};

export default ForgeUpload;
