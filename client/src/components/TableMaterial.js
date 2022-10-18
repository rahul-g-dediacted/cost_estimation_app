import React, { useState, useEffect } from 'react';
import axios from 'axios';
import BaseTable, { AutoResizer } from 'react-base-table';

import {
  Tooltip,
  Typography,
  Button,
  notification,
  Input,
  Modal,
  Checkbox,
  Table,
  Tabs,
  Select,
  Spin,
} from 'antd';
import _ from 'lodash';

import { getAllElementdbIdsOneModel } from '../functions/AutodeskForge';
import { responsiveMap } from 'antd/lib/_util/responsiveObserve';

import {getPricesButton} from './styles/TableMaterial';

const { Text } = Typography;
const { Option } = Select;
const THREE = window.THREE;
const { TabPane } = Tabs;

const log = console.log.bind(this);

const TableCell = ({ className, cellData }) => (
  <Tooltip title={cellData}>
    <Text className={className}>{cellData}</Text>
  </Tooltip>
);

const TableHeaderCell = ({ className, column }) => (
  <Text className={className}>{column.title}</Text>
);

function TableMaterial(props) {
  const getPrices = () => {
    handleLoadData(true,true);
  }
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [datas, _setDatas] = useState([]);
  const [totalData, setTotalData] = useState({
    totalEquipmentCost: 0,
    totalMaterialCost: 0,
    totalLaborCost: 0,
    grandTotalCost: 0,
  });
  const [costLines, setCostLines] = useState([]);
  const [selectedCostLine, setSelectedCostLine] = useState(null);
  const [costLinesOpt, setcostLinesOpt] = useState([]);
  const [list, setList] = useState([]);
  const [isSpinning, setIsSpinning] = useState(false);
  const [spinTip, setSpinTip] = useState('');
  const [dicIds, setDicIds] = useState([]);
  const [currentId, _setCurrentEditId] = useState(null);
  const [tempData, setTempData] = useState(null);
  const [columns, setColumns] = useState([
    {
      key: 'material',
      dataKey: 'material',
      dataIndex: 'material',
      title: 'Material',
      resizable: true,
      flexGrow: 1,
      flexShrink: 0,
    },
    {
      key: 'name',
      dataKey: 'name',
      dataIndex: 'name',
      title: 'Name',
      resizable: true,
      flexGrow: 1,
    },
    {
      key: 'price',
      dataKey: 'price',
      dataIndex: 'price',
      title: <div>Price<button style={getPricesButton} onClick={getPrices}>Get Prices</button></div>,
      resizable: true,
      width: 300,
      flexGrow: 2,
      render: (t, e) => {
        return e.isParrent ? (
          <div className='grid  grid-cols-2 gap-2'>
            <div>T.Equipment Cost :{e.totalEquipmentCost} </div>
            <div>T.Material Cost :{e.totalMaterialCost}</div>
            <div>T.Labor Cost :{e.totalLaborCost}</div>
            <div className='font-bold'>Total Cost :{e.grandTotalCost}</div>
          </div>
        ) : (
          <div className='grid  grid-cols-2 gap-2'>
            <div>Equipment Cost:{e.BaseCosts?.EquipmentCost}</div>
            <div>Material Cost:{e.BaseCosts?.MaterialCost}</div>
            <div>Labor Cost :{e.BaseCosts?.LaborCost}</div>
            <div className='font-bold'>
              Total Cost :{e.BaseCosts?.TotalCost}
            </div>
          </div>
        );
      },
    },
    {
      key: 'save',
      dataKey: 'save',
      title: 'Action',
      render: (text, record) => {
        return (
          record.isHasEdit && (
            <Button onClick={() => handleShowInputEdit(record)} type='primary'>
              Edit
            </Button>
          )
        );
      },
      width: 100,
    },
  ]);
  const [currentText, setCurrentText] = useState(null);
  const [isUpdateAll, setIsUpdateAll] = useState(false);
  const [currentRowEdit, setCurrentRowEdit] = useState(null);

  const [tabIndex, setTabIndex] = useState(1);

  const datasRef = React.useRef(datas);
  const currentIdRef = React.useRef(currentId);

  async function handleSave() {
    try {
      let ids = [currentId];

      let item = list.find((x) => x.id == currentId);
      ids = [item.dbId];

      if (isUpdateAll) {
        if (item) {
          let name = item.name.replace(item.modelId, '1');
          let list1 = list.map((x) => ({
            ...x,
            name1: x.name.replace(x.modelId, '1'),
          }));

          let similars = list1.filter((x) => x.name1 == name);
          ids = similars.map((x) => x.dbId);
        }
      }

      await axios.put('/api/function/animation/material', {
        material: currentText,
        ids,
      });

      await handleLoadData();

      notification['success']({
        message: 'Update Material',
        description: 'Update Material Successfully!',
      });
    } catch (error) {
      console.log('error', error);
      notification['error']({
        message: 'Update Material',
        description: 'Update Material Fail !' + error.message,
      });
    }
  }

  async function handleSaveCostLine() {
    try {
      let ids = [currentId];

      let item = list.find((x) => x.id == currentId);
      ids = [item.dbId];

      if (isUpdateAll) {
        if (item) {
          let name = item.name.replace(item.modelId, '1');
          let list1 = list.map((x) => ({
            ...x,
            name1: x.name.replace(x.modelId, '1'),
          }));

          let similars = list1.filter((x) => x.name1 == name);
          ids = similars.map((x) => x.dbId);
        }
      }

      await axios.put('/api/function/animation/cost-line-update', {
        costData: selectedCostLine,
        ids,
      });

      await handleLoadData();

      notification['success']({
        message: 'Update Cost Line',
        description: 'Update Line Successfully!',
      });
    } catch (error) {
      console.log('error', error);
      notification['error']({
        message: 'Update Cost Line',
        description: 'Update Cost Line Fail !' + error.message,
      });
    }
  }

  async function getCostLines(assemblyCode) {
    setIsSpinning(true);
    setSpinTip('Get Cost Lines...');
    let datas = await axios.get(
      '/api/function/animation/cost-line-by-catalog-id-assembly-code?assemblyCode=' +
        assemblyCode
    );

    setIsSpinning(false);

    console.log('datas',datas);

    setCostLines(datas.data);
    let opt = datas.data.map((x) => (
      <Option value={x._id}>{x.Description}</Option>
    ));
    setcostLinesOpt(opt);
  }

  const handleOk = () => {
    if (tabIndex == 1) {
      handleSave();
    } else {
      handleSaveCostLine();
    }
    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };

  function setDatas(data) {
    datasRef.current = data;
    _setDatas(data);
  }

  function setCurrentEditId(data) {
    currentIdRef.current = data;
    _setCurrentEditId(data);
  }

  const handleClickRow = (rowData) => {
    console.log('row', rowData);

    let clone = [...datas];

    for (let item of clone) {
      if (item.id == rowData.id) {
        item.isSelected = true;
      } else {
        item.isSelected = false;
      }

      item.children.forEach((sub) => {
        if (sub.id == rowData.id) {
          sub.isSelected = true;
        } else {
          sub.isSelected = false;
        }
      });
    }

    setDatas(clone);

    if (dicIds.length < 1) {
      getDicIds();
    }

    props.viewer.clearThemingColors();
    try {
      if (!rowData.children) {
        let ids = dicIds
          .filter((x) => x.revitId === rowData.modelId)
          .map((x) => x.viewId);
        props.viewer.isolate(ids);
        props.viewer.fitToView(ids);
        setColor(ids);
      } else {
        let childrenModalIds = rowData.children.map((x) => x.modelId);
        let ids = dicIds
          .filter((x) => childrenModalIds.includes(x.revitId))
          .map((x) => x.viewId);
        props.viewer.isolate(ids);
        props.viewer.fitToView(ids);
        setColor(ids);
      }
    } catch (error) {}
  };

  function setColor(ids) {
    let color = convertHexColorToVector4('#80ff80');
    ids.forEach((id) => {
      props.viewer.setThemingColor(id, color);
    });
  }

  function convertHexColorToVector4(value, transparent = 1) {
    let R = hexToR(value) / 255;
    let G = hexToG(value) / 255;
    let B = hexToB(value) / 255;
    return new THREE.Vector4(R, G, B, transparent);
  }

  function hexToR(h) {
    return parseInt(cutHex(h).substring(0, 2), 16);
  }
  function hexToG(h) {
    return parseInt(cutHex(h).substring(2, 4), 16);
  }
  function hexToB(h) {
    return parseInt(cutHex(h).substring(4, 6), 16);
  }

  function cutHex(h) {
    return h.charAt(0) === '#' ? h.substring(1, 7) : h;
  }

  function getDicIds() {
    let ar = [];
    if (props.viewer) {
      let ids = getAllElementdbIdsOneModel(props.viewer);
      if (_.isArray(ids)) {
        ids.forEach((id) => {
          props.viewer.model.getProperties(id, (modelAProperty) => {
            let pId = modelAProperty.properties.find(
              (p) => p.displayName === 'ElementId'
            );
            if (pId) {
              let revitId = pId.displayValue;
              ar.push({ viewId: id, revitId });
            }
          });
        });
      }
    }

    setDicIds(ar);
  }
  const rowEventHandlers = {
    onClick: handleClickRow.bind(this),
  };

  async function handleShowInputEdit(rowData) {
    setCurrentEditId(rowData.id);
    setIsModalVisible(true);
    console.log('rowData', rowData);
    await getCostLines(rowData.assemblyCode);
  }

  function onChangeCheckBox(e) {
    setIsUpdateAll(e.target.checked);
  }

  useEffect(() => {}, [props.data]);

  useEffect(() => {
    // getCostLines();
  }, []);

  function handleChangeMaterial(e) {
    setCurrentText(e.target.value);
  }

  useEffect(() => {
    if (props.load > 0) {
      handleLoadData();
    }
  }, [props.load]);

  useEffect(() => {
    console.log('props.selectedTableType', props.selectedTableType);
    console.log('tempData', tempData);

    if (props.selectedTableType != 'material') {
      setColumns([
        {
          key: 'material',
          dataKey: 'material',
          dataIndex: 'material',
          title: 'Category',
          resizable: true,
          flexGrow: 1,
          flexShrink: 0,
        },
        {
          key: 'name',
          dataKey: 'name',
          dataIndex: 'name',
          title: 'Name',
          resizable: true,
          flexGrow: 1,
        },
        {
          key: 'price',
          dataKey: 'price',
          dataIndex: 'price',
          title: <div>Price<button style={getPricesButton} onClick={getPrices}>Get Prices</button></div>,
          resizable: true,
          width: 300,
          flexGrow: 2,
          render: (t, e) => {
            return e.isParrent ? (
              <div className='grid  grid-cols-2 gap-2'>
                <div>T.Equipment Cost :{e.totalEquipmentCost} </div>
                <div>T.Material Cost :{e.totalMaterialCost}</div>
                <div>T.Labor Cost :{e.totalLaborCost}</div>
                <div className='font-bold'>Total Cost :{e.grandTotalCost}</div>
              </div>
            ) : (
              <div className='grid  grid-cols-2 gap-2'>
                <div>Equipment Cost:{e.BaseCosts?.EquipmentCost}</div>
                <div>Material Cost:{e.BaseCosts?.MaterialCost}</div>
                <div>Labor Cost :{e.BaseCosts?.LaborCost}</div>
                <div className='font-bold'>
                  Total Cost :{e.BaseCosts?.TotalCost}
                </div>
              </div>
            );
          },
        },
        {
          key: 'save',
          dataKey: 'save',
          title: 'Action',
          render: (text, record) => {
            return (
              record.isHasEdit && (
                <Button
                  onClick={() => handleShowInputEdit(record)}
                  type='primary'
                >
                  Edit
                </Button>
              )
            );
          },
          width: 100,
        },
      ]);
    } else if (props.selectedTableType != 'category') {
      setColumns([
        {
          key: 'material',
          dataKey: 'material',
          dataIndex: 'material',
          title: 'Material',
          resizable: true,
          flexGrow: 1,
          flexShrink: 0,
        },
        {
          key: 'name',
          dataKey: 'name',
          dataIndex: 'name',
          title: 'Name',
          resizable: true,
          flexGrow: 1,
        },
        {
          key: 'price',
          dataKey: 'price',
          dataIndex: 'price',
          title: <div>Price<button style={getPricesButton} onClick={getPrices}>Get Prices</button></div>,
          resizable: true,
          width: 300,
          flexGrow: 2,
          render: (t, e) => {
            return e.isParrent ? (
              <div className='grid  grid-cols-2 gap-2'>
                <div>T.Equipment Cost :{e.totalEquipmentCost} </div>
                <div>T.Material Cost :{e.totalMaterialCost}</div>
                <div>T.Labor Cost :{e.totalLaborCost}</div>
                <div className='font-bold'>Total Cost :{e.grandTotalCost}</div>
              </div>
            ) : (
              <div className='grid  grid-cols-2 gap-2'>
                <div>Equipment Cost:{e.BaseCosts?.EquipmentCost}</div>
                <div>Material Cost:{e.BaseCosts?.MaterialCost}</div>
                <div>Labor Cost :{e.BaseCosts?.LaborCost}</div>
                <div className='font-bold'>
                  Total Cost :{e.BaseCosts?.TotalCost}
                </div>
              </div>
            );
          },
        },
        {
          key: 'save',
          dataKey: 'save',
          title: 'Action',
          render: (text, record) => {
            return (
              record.isHasEdit && (
                <Button
                  onClick={() => handleShowInputEdit(record)}
                  type='primary'
                >
                  Edit
                </Button>
              )
            );
          },
          width: 100,
        },
      ]);
    } else if (props.selectedTableType != 'assembly') {
      setColumns([
        {
          key: 'assembly',
          dataKey: 'assembly',
          dataIndex: 'assembly',
          title: 'Assembly',
          resizable: true,
          flexGrow: 1,
          flexShrink: 0,
        },
        {
          key: 'name',
          dataKey: 'name',
          dataIndex: 'name',
          title: 'Name',
          resizable: true,
          flexGrow: 1,
        },
        {
          key: 'price',
          dataKey: 'price',
          dataIndex: 'price',
          title: <div>Price<button style={getPricesButton} onClick={getPrices}>Get Prices</button></div>,
          resizable: true,
          width: 300,
          flexGrow: 2,
          render: (t, e) => {
            return e.isParrent ? (
              <div className='grid  grid-cols-2 gap-2'>
                <div>T.Equipment Cost :{e.totalEquipmentCost} </div>
                <div>T.Material Cost :{e.totalMaterialCost}</div>
                <div>T.Labor Cost :{e.totalLaborCost}</div>
                <div className='font-bold'>Total Cost :{e.grandTotalCost}</div>
              </div>
            ) : (
              <div className='grid  grid-cols-2 gap-2'>
                <div>Equipment Cost:{e.BaseCosts?.EquipmentCost}</div>
                <div>Material Cost:{e.BaseCosts?.MaterialCost}</div>
                <div>Labor Cost :{e.BaseCosts?.LaborCost}</div>
                <div className='font-bold'>
                  Total Cost :{e.BaseCosts?.TotalCost}
                </div>
              </div>
            );
          },
        },
        {
          key: 'save',
          dataKey: 'save',
          title: 'Action',
          render: (text, record) => {
            return (
              record.isHasEdit && (
                <Button
                  onClick={() => handleShowInputEdit(record)}
                  type='primary'
                >
                  Edit
                </Button>
              )
            );
          },
          width: 100,
        },
      ]);
    }
    handleLoadData(false);
  }, [props.selectedTableType]);

  async function handleLoadData(isLoadApi = true, getPrices = false) {
    let res = null;

    const selectedProjectId = localStorage.getItem('selectedProjectId');
    const selectedModelId = localStorage.getItem('selectedModelId');

    if (isLoadApi) {
      res = await axios.get(        
        '/api/function/animation/material/' +
        selectedProjectId + '/' + selectedModelId             
      );

      setTempData(res);
    } else {
      res = tempData;
    }

    try {
      let data = res.data.map((x, index) => {
        let material =
          x.Structural_Material === '' ? '' : x.Structural_Material;
        if (props.selectedTableType == 'category') {
          material = x.Category === '' ? '' : x.Category;
        }
        if (props.selectedTableType == 'assembly') {
          material = x.Assembly_Code === '' ? '' : x.Assembly_Code;
        }

        if(getPrices){
          let obj = {
            id: 'c' + index,
            dbId: x._id,
            modelId: x.model_id,
            name: x.Family,
            ML_filled: x.ML_filled,
            material,
            price: x.Price,
            modelName: x.model_name,
            parentId: x.code,
            isHasEdit: true,
            isParrent: false,
            assemblyCode: x.Assembly_Code,
            CostLineId: x.CostLineId,
            BaseCosts: x.BaseCosts,
          };
          return obj;
        }
        else if (!getPrices){
          let obj = {
            id: 'c' + index,
            dbId: x._id,
            modelId: x.model_id,
            name: x.Family,
            ML_filled: x.ML_filled,
            material,
            price: x.Price,
            modelName: x.model_name,
            parentId: x.code,
            isHasEdit: true,
            isParrent: false,
            assemblyCode: x.Assembly_Code,
            CostLineId: x.CostLineId,            
          };
          return obj;
        }              
      });

      setList(data);

      for(let object of data){
        if(object.assemblyCode===''){
          log('missingAssemblyCode');
          props.missingAssemblyCodeHandler();
          break 
        }
      }      

      data = _.orderBy(data, 'name');

      let dic = _.groupBy(data, 'material');

      let keys = Object.keys(dic);
      keys.sort();

      let dt = keys.map((key, index) => ({
        id: index,
        name: `Count : ${dic[key].length}`,
        material: key,
        price: 0,
        children: dic[key],
        isHasEdit: false,
        isParrent: true,
        totalEquipmentCost: _.round(
          _.sum(
            dic[key]
              .filter((d) => d.BaseCosts)
              .map((d) => d.BaseCosts.EquipmentCost)
          ),
          2
        ),
        totalMaterialCost: _.round(
          _.sum(
            dic[key]
              .filter((d) => d.BaseCosts)
              .map((d) => d.BaseCosts.MaterialCost)
          )
        ),
        totalLaborCost: _.round(
          _.sum(
            dic[key]
              .filter((d) => d.BaseCosts)
              .map((d) => d.BaseCosts.LaborCost)
          )
        ),
        grandTotalCost: _.round(
          _.sum(
            dic[key]
              .filter((d) => d.BaseCosts)
              .map((d) => d.BaseCosts.TotalCost)
          )
        ),
      }));

      let obj = {
        totalEquipmentCost: _.round(
          _.sum(
            data
              .filter((d) => d.BaseCosts)
              .map((d) => d.BaseCosts.EquipmentCost)
          ),
          2
        ),
        totalMaterialCost: _.round(
          _.sum(
            data.filter((d) => d.BaseCosts).map((d) => d.BaseCosts.MaterialCost)
          )
        ),
        totalLaborCost: _.round(
          _.sum(
            data.filter((d) => d.BaseCosts).map((d) => d.BaseCosts.LaborCost)
          )
        ),
        grandTotalCost: _.round(
          _.sum(
            data.filter((d) => d.BaseCosts).map((d) => d.BaseCosts.TotalCost)
          )
        ),
      };

      setTotalData(obj);

      let noneItem = dt.find((x) => x.material == '');
      if (noneItem) {
        noneItem.material = 'None';
        noneItem.children.forEach((x) => (x.material = 'None'));
      }

      setDatas(dt);      
    } catch (error) {
      setDatas([]);
    }
  }

  return (
    <>      
      <AutoResizer>
        {({ width, height }) => [
          <div style={{ width: width, height: height - 100 }}>
            <Table
              expandColumnKey={'material'}
              width={width}
              height={height}
              columns={columns}
              rowKey='id'
              data={datas}
              bordered
              dataSource={datas}
              rowHeight={60}
              scroll={{ y: height * 0.8 }}
              pagination={false}
              components={{ TableCell, TableHeaderCell }}
              rowEventHandlers={rowEventHandlers}
              rowClassName={(record, index) => {
                if (record.isSelected == true) {
                  return 'table-row-selected ';
                }
                return record.ML_filled == 1 ? 'table-row-blue' : '';
              }}
              onRow={(record, rowIndex) => {
                return {
                  onClick: (event) => {
                    handleClickRow(record);
                  }, // click row
                };
              }}
            />
            <div className='mt-2 ml-2'>
              <div className='grid  grid-cols-2 gap-2'>              
                <div>Total Equipment Cost :{totalData.totalEquipmentCost} </div>
                <div>Total Material Cost :{totalData.totalMaterialCost}</div>
                <div>Total Labor Cost :{totalData.totalLaborCost}</div>
                <div className='font-bold'>
                  Total Project Cost :{totalData.grandTotalCost}
                </div>
              </div>
            </div>

            <Modal
              visible={isModalVisible}
              onOk={handleOk}
              onCancel={handleCancel}
              width={700}
            >
              <div>
                <Tabs defaultActiveKey='1' onChange={(e) => setTabIndex(e)}>
                  <TabPane tab='Material' key='1'>
                    <div className=''>
                      <p className='mr-1'>Material :</p>
                      <Input
                        value={currentText}
                        onChange={(e) => handleChangeMaterial(e)}
                      />
                      <Checkbox className='mt-3' onChange={onChangeCheckBox}>
                        Update for all the similar elements
                      </Checkbox>
                    </div>
                  </TabPane>
                  <TabPane tab='Cost Line' key='2'>
                    <div className=''>
                      <Spin spinning={isSpinning} tip={spinTip}>
                        <p className='mr-1'>Cost Line :</p>
                        <Select
                          className='w-100'
                          showSearch
                          onChange={(e) => {
                            let item = costLines.find((x) => x._id == e);
                            setSelectedCostLine(item);
                          }}
                          placeholder='Select cost line'
                          optionFilterProp='children'
                          filterOption={(input, option) =>
                            option.children
                              .toLowerCase()
                              .indexOf(input.toLowerCase()) >= 0
                          }
                        >
                          {costLinesOpt}
                        </Select>

                        <Checkbox className='mt-3' onChange={onChangeCheckBox}>
                          Update for all the similar elements
                        </Checkbox>
                      </Spin>
                    </div>
                  </TabPane>
                </Tabs>
              </div>
            </Modal>
          </div>,
        ]}
      </AutoResizer>
    </>
  );
}

export default TableMaterial;
