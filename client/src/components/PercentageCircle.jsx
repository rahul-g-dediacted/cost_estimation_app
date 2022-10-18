import React from "react";
import axios from "axios";
import _ from "lodash";
import { Modal, Button, notification } from "antd";
import image from "../image/warning.png";

class PercentageCircle extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      percentage: "0",
      circumference: "0, 100",
      isModalVisible: false,
      updateDBCall: false,
    };
    this.handleOk = this.handleOk.bind(this);
  }

  componentDidMount = () => {};

  checkScore(isShowDialog = true) {
    const selectedProjectId = localStorage.getItem("selectedProjectId");
    const selectedModelId = localStorage.getItem("selectedModelId");
    axios
      .post("/api/function/animation/test/" + selectedProjectId + "/" + selectedModelId)
      .then((res) => {
        console.log(res.data);
        let temp = [];
        _.forEach(res.data, (v, k) => {
          if (v !== null)
            temp.push(
              k.toString() + ": " + (v !== null ? v.toString() + " %" : "")
            );
        });

        this.setState({ percentage: res.data["Score"] });

        window.store.dispatch({ type: "PERCENT", payload: res.data["Score"] });
        
        if (isShowDialog) {
          this.setState({ isModalVisible: res.data["Score"] < 100 });
        }

        this.setState({ circumference: res.data["Score"] + ", 100" });

        //calling parent percentage circle state handler
        this.props.percentageCircleStateHandler();
      });
  }

  componentDidUpdate = (prevProps, prevState) => {
    // call to load checkScore() from parent
    if(this.props.shouldOpen===true){
      this.checkScore();
    }
    // load check score function on project change from list and on uploading
    // if (
    //   prevProps.selectedProjectId != this.props.selectedProjectId &&
    //   this.props.selectedProjectId
    // ) {
    //   console.log("this.props.selectedProjectId", this.props.selectedProjectId);
    //   this.checkScore();
    // }
  };

  handleOk(flag = true) {
    this.props.AIWaitModalHandler('visible');
    this.setState({ isModalVisible: false });

    const selectedProjectId = localStorage.getItem("selectedProjectId");
    const selectedModelId = localStorage.getItem("selectedModelId");

    if (flag) {
      axios
        .get(
          "http://localhost:5000/updatedb/" + 
          selectedProjectId + '/' + selectedModelId
         )
        .then((res) => {
          if (res.data.updateMongo === "Success") {
            axios
              .post(
                "/api/function/animation/test/" + selectedProjectId + "/" + selectedModelId
              )
              .then((res) => {
                this.props.AIWaitModalHandler('disable');
                this.setState({ percentage: res.data["Score"] });
                window.store.dispatch({ type: "PERCENT", payload: res.data["Score"] });
                this.setState({ circumference: res.data["Score"] + ", 100" });
              });

            // notification on top right
            // notification["success"]({
            //   message: "Infomation",
            //   description: "A.I engine has been filled data successfully!",
            // });
          } else {
            console.log("> Did not update Mongo DB");
          }
        })
        .catch((res) => {
          console.log("> Error Making the updateDB API call.");
        });
    } else {
    }
  }

  render() {
    return (
      <div style={this.props.style} className="flex-wrapper">
        <p style={{ textAlign: "center" }}>
          {" "}
          <b>Score</b>{" "}
        </p>
        <div className="single-chart">
          <svg viewBox="0 0 36 36" className="circular-chart ">
            <path
              className="circle-bg"
              d="M18 2.0845
                    a 15.9155 15.9155 0 0 1 0 31.831
                    a 15.9155 15.9155 0 0 1 0 -31.831"
            />
            <path
              className="circle"
              stroke="yellow"
              strokeDasharray={this.state.circumference}
              d="M18 2.0845
                    a 15.9155 15.9155 0 0 1 0 31.831
                    a 15.9155 15.9155 0 0 1 0 -31.831"
            />
            <text x="18" y="20.35" className="percentage">
              {this.props.percentScore}
            </text>
          </svg>
        </div>

        <Modal
          title="Information"
          visible={this.state.isModalVisible}
          onCancel={() => this.setState({ isModalVisible: false })}
          footer={[
            <Button
              key="submit"
              type="primary"
              onClick={() => this.handleOk(true)}
            >
              Yes !
            </Button>,
            <Button
              key="link"
              type="primary"
              onClick={() => this.handleOk(false)}
            >
              No , I got this!
            </Button>,
          ]}
        >
          <div className="grid  grid-cols-4">
            <div className=" col-span-1">
              <img src={image} alt="" />
            </div>
            <div className=" col-span-3 bottom-0">
              {/* <p>
                Your model is missing important information like Structural
                material, Assembly codes, Levels and Functions. Would you like
                our A.I engine to fill this data for you?
              </p> */}
              <p>
                “Your model is only “{this.state.percentage} % '' complete.
                It is missing important information like, Levels, Assembly
                codes, Location_lines and Functions. Would you like our A.I
                engine to fill this data for you?
              </p>
            </div>
          </div>
        </Modal>
      </div>
    );
  }
}

export default PercentageCircle;
