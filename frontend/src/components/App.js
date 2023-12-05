import Header from "./body/header/Header";
import Footer from "./body/footer/Footer";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Client from "./main/client/Client";
import Category from "./main/category/Category";
import TeamMember from "./main/teamMember/TeamMember";
import Report from "./main/report/Report";
import TimeSheet from "./main/timeSheet/TimeSheet";
import Project from "./main/project/Project";

function App() {
  return (
    <Router>
      <div className="App">
        <Header />
        <Route path="/client" component={Client} />
        <Route path="/category" component={Category} />
        <Route path="/teammember" component={TeamMember} />
        <Route path="/report" component={Report} />
        <Route path="/timesheet" component={TimeSheet} />
        <Route path="/project" component={Project} />

        <Footer />
      </div>
    </Router>
  );
}

export default App;
