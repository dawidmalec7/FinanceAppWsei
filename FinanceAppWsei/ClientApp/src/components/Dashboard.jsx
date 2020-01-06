import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import MoneyBoxes from "./MoneyBoxes";

class Dashboard extends Component {
  render() {
    const { logout } = this.props;
    return (
      <Router>
        <div>
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <ul className="navbar-nav mr-auto">
              <li>
                <Link to={"/moneyboxes"} className="nav-link">
                  Moneyboxes
                </Link>
              </li>
              <li>
                <button className="btn btn-danger" onClick={logout}>Logout</button>
              </li>
            </ul>
          </nav>
          <hr />
          <Switch>
            <Route path="/moneyboxes" component={MoneyBoxes} />
          </Switch>
        </div>
      </Router>
    );
  }
}

export default Dashboard;
