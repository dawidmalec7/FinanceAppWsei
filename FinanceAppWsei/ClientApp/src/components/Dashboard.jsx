import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import "./Styles/Dashboard.css";
import "./Styles/Main.css";
import MoneyBoxes from "./MoneyBoxes/MoneyBoxes";
import Incomes from "./Incomes/Incomes";
import Expenses from "./Expenses/Expenses";
import Categories from "./Categories/Categories";
import AccountsAPI from "../api/accounts";
class Dashboard extends Component {
  state = {
    balance: 0
  };
  componentDidMount() {
    this.getBallance();
  }

  getBallance = () => {
    AccountsAPI.get().then(response => {
      this.setState({ balance: response.data.Data });
    });
  };

  render() {
    const { logout } = this.props;
    const { balance } = this.state;
    return (
      <Router>
        <div className="box">
          <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
            <ul className="navbar-nav mr-auto">
              <li>
                <Link to={"/Incomes/incomes"} className="nav-link">
                  Incomes
                </Link>
              </li>
              <li>
                <Link to={"/Expenses/expenses"} className="nav-link">
                  Expenses
                </Link>
              </li>
              <li>
                <Link to={"/MoneyBoxes/moneyboxes"} className="nav-link">
                  Moneyboxes
                </Link>
              </li>
              <li>
                <Link to={"/Categories/Categories"} className="nav-link">
                  Categories
                </Link>
              </li>
            </ul>
            <span className="balance">Your balance {balance}$</span>
            <button className="btn btn-danger" onClick={logout}>
                Logout
            </button>
          </nav>
    
          <Switch>
            <Route path="/MoneyBoxes/moneyboxes" component={MoneyBoxes} />
            <Route
              path="/Incomes/incomes"
              component={props => (
                <Incomes {...props} getBallance={this.getBallance} />
              )}
            />
            <Route
              path="/Expenses/expenses"
              component={props => (
                <Expenses {...props} getBallance={this.getBallance} />
              )}
            />
            <Route
              path="/Categories/Categories"
              component={props => (
                <Categories {...props} getBallance={this.getBallance} />
              )}
            />
          </Switch>
        </div>
      </Router>
    );
  }
}

export default Dashboard;
