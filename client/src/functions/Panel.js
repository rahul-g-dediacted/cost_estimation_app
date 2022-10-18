const Autodesk = window.Autodesk;

const showSpinner = () => {
  const spinner = document.getElementById("loading-screen-forge");
  if (spinner) spinner.style.display = 'block';
};
const hideSpinner = () => {
  const spinner = document.getElementById("loading-screen-forge");
  if (spinner) spinner.style.display = 'none';
};

export default function Panel(viewer, container, id, title, options, categories) {
    this.viewer = viewer;
    Autodesk.Viewing.UI.DockingPanel.call(this, container, id, title, options);
  
    // the style of the docking panel
    // use this built-in style to support Themes on Viewer 4+
    this.container.classList.add("docking-panel-container-solid-color-a");
    this.container.style.top = "10px";
    this.container.style.left = "10px";
    this.container.style.width = "auto";
    this.container.style.height = "auto";
    this.container.style.resize = "auto";
  
    // this is where we should place the content of our panel
    var div = document.createElement("div");
    div.style.margin = "20px";
  
    const htmlCategory = categories
      .map((c) => `<option value="${c}">${c}</option>`)
      .join(" ");
    const html = `
    <div style="color: black">
      <select name="cate" id="categories">
        <option value="All category">All category</option>
        ${htmlCategory}
      </select>
      <button id = "download-excel-category">Download</button>
    </div>
  
    `;
    div.innerHTML = html;
    this.container.appendChild(div);
    const downloadBtn = document.getElementById("download-excel-category");
    if (downloadBtn) {
      downloadBtn.addEventListener("click", () => {
        const select = document.getElementById("categories");
        console.log(select.value);
        if (select) {
          showSpinner();
          const fileRequest = JSON.stringify({ cate: select.value });
          var request = new XMLHttpRequest();
          request.open("POST", "api/forge/downloadByCategoriesExcel", true);
          request.setRequestHeader("Content-type", "application/json");
          request.responseType = "blob";
          request.send(fileRequest);
          request.onload = function () {
            if (this.status === 200) {
              console.log(this.status);
              var blob = this.response;
              var fileName = request.getResponseHeader("Content-Disposition");
              if (window.navigator.msSaveOrOpenBlob) {
                window.navigator.msSaveBlob(blob, fileName);
              } else {
                var downloadLink = window.document.createElement("a");
                var contentTypeHeader = request.getResponseHeader("Content-Type");
                downloadLink.href = window.URL.createObjectURL(
                  new Blob([blob], { type: contentTypeHeader })
                );
                downloadLink.download = "download.xlsx";
                document.body.appendChild(downloadLink);
                downloadLink.click();
                document.body.removeChild(downloadLink);
              }
              hideSpinner();
            } else {
              console.error('error in creating an downloading excel sheet')
            }
          };
        }
      });
    }
  }
  Panel.prototype = Object.create(Autodesk.Viewing.UI.DockingPanel.prototype);
  Panel.prototype.constructor = Panel;
  