import React, { useState, useEffect } from "react";
import BaseTable, { AutoResizer } from "react-base-table";
import {
  Tooltip,
  Typography,
  Input,
  Select,
  Button,
  notification,
  Checkbox,
  Modal,
  Table,
} from "antd";

import _ from "lodash";

import axios from "axios";
import { getAllElementdbIdsOneModel } from "../functions/AutodeskForge";
const { Text } = Typography;
const { Option } = Select;

const TableCell = ({ className, cellData }) => (
  <Tooltip title={cellData}>
    <Text className={className}>{cellData}</Text>
  </Tooltip>
);

const TableHeaderCell = ({ className, column }) => (
  <Text className={className}>{column.title}</Text>
);

function TableAssemblyCode(props) {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [datas, _setDatas] = useState([]);
  const [list, setList] = useState([]);
  const [dicIds, setDicIds] = useState([]);
  const [currentId, _setCurrentEditId] = useState(null);
  const [currentText, setCurrentText] = useState(null);
  const [isUpdateAll, setIsUpdateAll] = useState(false);

  const datasRef = React.useRef(datas);
  const currentIdRef = React.useRef(currentId);

  function setDatas(data) {
    datasRef.current = data;
    _setDatas(data);
  }

  function setCurrentEditId(data) {
    currentIdRef.current = data;
    _setCurrentEditId(data);
  }

  function handleClickRow(rowData) {
    console.log("rowData", rowData);

    if (dicIds.length < 1) {
      getDicIds();
    }

    let ids = dicIds
      .filter((x) => x.revitId === rowData.modelId)
      .map((x) => x.viewId);

    if (_.isArray(rowData.children)) {
      let modelIds = rowData.children.map((x) => x.modelId);
      ids = dicIds
        .filter((x) => modelIds.includes(x.revitId))
        .map((x) => x.viewId);
    }

    props.viewer.isolate(ids);
    props.viewer.fitToView(ids);
  }

  function onChangeCheckBox(e) {
    setIsUpdateAll(e.target.checked);
  }

  function handleChangeMaterial(e) {
    setCurrentText(e.target.value);
  }

  async function handleSave() {
    let ids = [];
    let item = list.find((x) => x.id == currentId);
    ids = [item.dbId];

    if (isUpdateAll) {
      if (item) {
        let name = item.name.replace(item.modelId, "1");
        let list1 = list.map((x) => ({
          ...x,
          name1: x.name.replace(x.modelId, "1"),
        }));

        let similars = list1.filter((x) => x.name1 == name);
        ids = similars.map((x) => x.dbId);

        console.log("list1", list1);
        console.log("name", name);
      }
    }

    try {
      await axios.put("/api/function/animation/assembly-code-edit", {
        code: currentText,
        ids,
      });

      await handleLoadAssemblyCode();

      notification["success"]({
        message: "Update Assembly Code",
        description: "Update Assembly Code Successfully!",
      });
    } catch (error) {
      console.log("error", error);
      notification["error"]({
        message: "Update Assembly Code",
        description: "Update Assembly Code Fail !" + error.message,
      });
    }
  }

  function handleChangeCode(e, rowData) {
    let newData = _.clone(datasRef.current);
    let item = newData.find((x) => x.modelId === rowData.modelId);
    if (item != null) {
      item.code = e.target.value;
      setDatas(newData);
    }
  }

  const columns = [
    {
      key: "name",
      dataKey: "name",
      dataIndex: "name",
      title: "Family",
      resizable: true,
      width: 200,
      flexGrow: 1,
      flexShrink: 0,
      dataIndex: "name",
    },
    {
      key: "code",
      dataKey: "code",
      dataIndex: "code",
      title: "Code",
      resizable: true,
      // cellRenderer: ({ rowData, cellData }) => [
      //   <Input
      //     value={cellData}
      //     onChange={(e) => handleChangeCode(e, rowData)}
      //   />,
      // ],
      flexGrow: 1,
    },

    {
      key: "modelName",
      dataKey: "modelName",
      dataIndex: "modelName",
      title: "Model name",
      resizable: true,
      flexGrow: 2,
    },
    {
      key: "save",
      dataKey: "save",
      title: "Action",
      width: 100,
      render: (t, rowData) => {
        return (
          rowData.isHasEdit && (
            <Button onClick={() => handleShowInputEdit(rowData)} type="primary">
              Edit
            </Button>
          )
        );
      },
      flexGrow: 3,
    },
  ];

  const rowEventHandlers = {
    onClick: handleClickRow.bind(this),
  };

  useEffect(() => {
    if (props.load > 0) {
      handleLoadAssemblyCode();
      getDicIds();
    }
  }, [props.load]);

  function getDicIds() {
    let ar = [];
    if (props.viewer) {
      let ids = getAllElementdbIdsOneModel(props.viewer);
      if (_.isArray(ids)) {
        ids.forEach((id) => {
          props.viewer.model.getProperties(id, (modelAProperty) => {
            let pId = modelAProperty.properties.find(
              (p) => p.displayName === "ElementId"
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

  function handleShowInputEdit(rowData) {
    setCurrentEditId(rowData.id);
    setIsModalVisible(true);
  }

  async function handleLoadAssemblyCode() {
    const selectedProjectId = localStorage.getItem("selectedProjectId");
    let res = await axios.get(
      "/api/function/animation/assembly-code/" + selectedProjectId
    );

    if (res.data.length < 1) {
      notification["success"]({
        message: "Info",
        description: "No missing assembly code!",
      });
    }
    let data2 = res.data
      .filter((x) => _.isEmpty(x.Assembly_Code) || _.isNil(x.Assembly_Code))
      .map((x, index) => ({
        id: "c" + index,
        dbId: x._id,
        modelId: x.model_id,
        name: x.Family.replace(`[${x.model_id}]`, ""),
        code: "None",
        modelName: x.model_name,
        parentId: x.code,
        isHasEdit: true,
      }));

    data2 = _.orderBy(data2, "name");
    setList(data2);

    try {
      let dic = _.groupBy(data2, "name");
      console.log("dic", dic);
      let dt = Object.keys(dic).map((key, index) => ({
        id: index,
        name: key,
        children: dic[key],
        isHasEdit: false,
        code: "None",
      }));

      setDatas(dt);
    } catch (error) {
      setDatas([]);
    }
  }

  const handleOk = () => {
    handleSave();

    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };

  return (
    <AutoResizer>
      {({ width, height }) => (
        <div style={{ width: width, height: height - 100 }}>
          <Table
            expandColumnKey={"name"}
            width={width}
            bordered
            height={height}
            columns={columns}
            data={datas}
            scroll={{ y: height * 0.8 }}
            pagination={false}
            rowKey="id"
            dataSource={datas}
            components={{ TableHeaderCell, TableCell }}
            rowEventHandlers={rowEventHandlers}
            onRow={(record, rowIndex) => {
              return {
                onClick: (event) => {
                  handleClickRow(record);
                }, // click row
              };
            }}
          />
          <Modal
            title="Edit Assembly Code"
            visible={isModalVisible}
            onOk={handleOk}
            onCancel={handleCancel}
          >
            <div>
              <div className="">
                <p className="mr-1">Assemby Code :</p>
                <Input
                  value={currentText}
                  onChange={(e) => handleChangeMaterial(e)}
                />

                <Checkbox className="mt-3" onChange={onChangeCheckBox}>
                  Update for all the similar elements
                </Checkbox>
              </div>
            </div>
          </Modal>
        </div>
      )}
    </AutoResizer>
  );
}

export default TableAssemblyCode;
