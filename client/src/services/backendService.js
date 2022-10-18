import axios from "axios";

export const handleGetDataCSV = async () => {
  const selectedProjectId = localStorage.getItem("selectedProjectId");
  axios
    .get("http://localhost:5000/getdf02csv/" + selectedProjectId)
    .then((res) => {
      console.log("Retrieved data from server");
      //console.log(res.data)
      var hiddenElement = document.createElement("a");
      hiddenElement.className = "temp-hidden-link";
      hiddenElement.href = "data:text/csv;charset=utf-8," + encodeURI(res.data);
      hiddenElement.target = "_blank";
      hiddenElement.download = "data.csv";
      hiddenElement.click();
      var temp = document.getElementsByClassName("temp-hidden-link");
      temp.forEach((element) => {
        element.parentNode.removeChild(element);
      });
      //hiddenElement.parentNode.removeChild(hiddenElement);
    })
    .catch((err) => {
      console.log(err);
    });
};

export const handleGetScheduleDataCSV = async () => {
  let projectId = localStorage.getItem("selectedProjectId");
  axios
    .get("http://localhost:5000/getschedulecsv/" + projectId)
    .then((res) => {
      console.log("Retrieved schedule data from server");
      //console.log(res.data)
      var hiddenElement = document.createElement("a");
      hiddenElement.className = "temp-hidden-link";
      hiddenElement.href = "data:text/csv;charset=utf-8," + encodeURI(res.data);
      hiddenElement.target = "_blank";
      hiddenElement.download = "schedule.csv";
      hiddenElement.click();
      var temp = document.getElementsByClassName("temp-hidden-link");
      temp.forEach((element) => {
        element.parentNode.removeChild(element);
      });
    })
    .catch((err) => {
      console.log(err);
    });
};

export const handleGetMissingDataCSV = async () => {

  let projectId = localStorage.getItem("selectedProjectId");

  axios
    .get("http://localhost:5000/getmissingdatacsv/"+projectId)
    .then((res) => {
      console.log("Retrieved schedule data from server");
      //console.log(res.data)
      var hiddenElement = document.createElement("a");
      hiddenElement.className = "temp-hidden-link";
      hiddenElement.href = "data:text/csv;charset=utf-8," + encodeURI(res.data);
      hiddenElement.target = "_blank";
      hiddenElement.download = "missing.csv";
      hiddenElement.click();
      var temp = document.getElementsByClassName("temp-hidden-link");
      temp.forEach((element) => {
        element.parentNode.removeChild(element);
      });
    })
    .catch((err) => {
      console.log(err);
    });
};
