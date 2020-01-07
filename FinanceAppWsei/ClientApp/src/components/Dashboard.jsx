import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import MoneyBoxes from "./MoneyBoxes/MoneyBoxes";
import Accounts from "./Accounts/Accounts";
import Incomes from "./Incomes/Incomes";

class Dashboard extends Component {
  render() {
    const { logout } = this.props;
    return (
      <Router>
        <div>
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <ul className="navbar-nav mr-auto">
              <li>
                <Link to={"/MoneyBoxes/moneyboxes"} className="nav-link">
                  Moneyboxes
                </Link>
              </li>
              <li>
                <Link to={"/Accounts/accounts"} className="nav-link">
                  Accounts
                </Link>
              </li>
              <li>
                <Link to={"/Incomes/incomes"} className="nav-link">
                  Incomes
                </Link>
              </li>
              <li>
                <button className="btn btn-danger" onClick={logout}>Logout</button>
              </li>
            </ul>
          </nav>
          <hr />
          <Switch>
            <Route path="/MoneyBoxes/moneyboxes" component={MoneyBoxes} />
          </Switch>
          <Switch>
            <Route path="/Accounts/accounts" component={Accounts} />
          </Switch>
          <Switch>
            <Route path="/Incomes/incomes" component={Incomes} />
          </Switch>
        </div>
      </Router>
    );
  }
}

export default Dashboard;
