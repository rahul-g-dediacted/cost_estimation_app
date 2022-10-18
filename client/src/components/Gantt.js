import "../App.css";
import {
  GanttComponent,
  EditDialogFieldsDirective,
  DayMarkers,
  EditDialogFieldDirective,
  Inject,
  Edit,
  Selection,
  Toolbar,
  ColumnsDirective,
  ColumnDirective,
  EventMarkersDirective,
  EventMarkerDirective,
} from "@syncfusion/ej2-react-gantt";
import { editingData, editingResources } from "./data";
import { SampleBase } from "./sample-base";
export default class Gantt extends SampleBase {
  constructor() {
    super(...arguments);
    this.taskFields = {
      id: "TaskID",
      name: "TaskName",
      startDate: "StartDate",
      endDate: "EndDate",
      duration: "Duration",
      progress: "Progress",
      dependency: "Predecessor",
      child: "subtasks",
      notes: "info",
      resourceInfo: "resources",
    };
    this.resourceFields = {
      id: "resourceId",
      name: "resourceName",
    };
    this.editSettings = {
      allowAdding: true,
      allowEditing: true,
      allowDeleting: true,
      allowTaskbarEditing: true,
      showDeleteConfirmDialog: true,
    };
    this.splitterSettings = {
      columnIndex: 2,
    };
    this.projectStartDate = new Date("03/25/2019");
    this.projectEndDate = new Date("07/28/2019");
    this.gridLines = "Both";
    this.toolbar = [
      "Add",
      "Edit",
      "Update",
      "Delete",
      "Cancel",
      "ExpandAll",
      "CollapseAll",
      "Indent",
      "Outdent",
    ];
    this.timelineSettings = {
      topTier: {
        unit: "Week",
        format: "MMM dd, y",
      },
      bottomTier: {
        unit: "Day",
      },
    };
    this.labelSettings = {
      leftLabel: "TaskName",
      rightLabel: "resources",
    };
    this.eventMarkerDay1 = new Date("4/17/2019");
    this.eventMarkerDay2 = new Date("5/3/2019");
    this.eventMarkerDay3 = new Date("6/7/2019");
    this.eventMarkerDay4 = new Date("7/16/2019");
  }
  render() {
    return (
      <div className="control-pane">
        <div className="control-section">
          <GanttComponent
            id="Editing"
            dataSource={editingData}
            dateFormat={"MMM dd, y"}
            treeColumnIndex={1}
            allowSelection={true}
            showColumnMenu={false}
            highlightWeekends={true}
            allowUnscheduledTasks={true}
            projectStartDate={this.projectStartDate}
            projectEndDate={this.projectEndDate}
            taskFields={this.taskFields}
            timelineSettings={this.timelineSettings}
            labelSettings={this.labelSettings}
            splitterSettings={this.splitterSettings}
            height="410px"
            editSettings={this.editSettings}
            gridLines={this.gridLines}
            toolbar={this.toolbar}
            resourceFields={this.resourceFields}
            resources={editingResources}
          >
            <ColumnsDirective>
              <ColumnDirective field="TaskID" width="60"></ColumnDirective>
              <ColumnDirective
                field="TaskName"
                headerText="Job Name"
                width="250"
                clipMode="EllipsisWithTooltip"
              ></ColumnDirective>
              <ColumnDirective field="StartDate"></ColumnDirective>
              <ColumnDirective field="Duration"></ColumnDirective>
              <ColumnDirective field="Progress"></ColumnDirective>
              <ColumnDirective field="Predecessor"></ColumnDirective>
            </ColumnsDirective>
            <EditDialogFieldsDirective>
              <EditDialogFieldDirective
                type="General"
                headerText="General"
              ></EditDialogFieldDirective>
              <EditDialogFieldDirective type="Dependency"></EditDialogFieldDirective>
              <EditDialogFieldDirective type="Resources"></EditDialogFieldDirective>
              <EditDialogFieldDirective type="Notes"></EditDialogFieldDirective>
            </EditDialogFieldsDirective>
            <EventMarkersDirective>
              <EventMarkerDirective
                day={this.eventMarkerDay1}
                label="Project approval and kick-off"
              ></EventMarkerDirective>
              <EventMarkerDirective
                day={this.eventMarkerDay2}
                label="Foundation inspection"
              ></EventMarkerDirective>
              <EventMarkerDirective
                day={this.eventMarkerDay3}
                label="Site manager inspection"
              ></EventMarkerDirective>
              <EventMarkerDirective
                day={this.eventMarkerDay4}
                label="Property handover and sign-off"
              ></EventMarkerDirective>
            </EventMarkersDirective>
            <Inject services={[Edit, Selection, Toolbar, DayMarkers]} />
          </GanttComponent>
          <div style={{ float: "right", margin: "10px" }}>
            Source:
            <a
              href="https://en.wikipedia.org/wiki/Construction"
              target="_blank"
            >
              https://en.wikipedia.org/
            </a>
          </div>
        </div>
      </div>
    );
  }
}
