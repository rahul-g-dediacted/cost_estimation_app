import ForgeViewerProject from "./components/ForgeViewerProject";
import ForgeUpload from "./components/ForgeUpload";
import AddinControl from "./components/AddinControl";
import Gantt from "./components/Gantt";
import { Route } from "react-router-dom";
import history from "./history";
import "semantic-ui-css/semantic.min.css";
import "primereact/resources/themes/saga-blue/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";


function App(props) {
  return (
    <>
      <Route
        location={props.location}
        history={history}
        path='/project'
        exact
        component={ForgeViewerProject}
      />
      <Route
        location={props.location}
        history={history}
        path='/'
        exact
        component={ForgeUpload}
      />
      <Route
        location={props.location}
        history={history}
        path='/addin'
        exact
        component={AddinControl}
      />
            <Route
        location={props.location}
        history={history}
        path='/gantt'
        exact
        component={Gantt}
      />
    </>
  );
}

export default App;
