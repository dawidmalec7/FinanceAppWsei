import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import MoneyBoxes from "./MoneyBoxes/MoneyBoxes";
import Incomes from "./Incomes/Incomes";
import Expenses from "./Expenses/Expenses";
import AccountsAPI from "../api/accounts";
class Dashboard extends Component {

  state = {
    balance: 0
  }
  componentDidMount(){
    this.getBallance();
  }

  getBallance = () =>{
    AccountsAPI.get().then(response =>{
      this.setState({ balance: response.data.Data})
    })
  }

  render() {
    const { logout } = this.props;
    const { balance } = this.state;
    return (
      <Router>
        <div>
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
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
                <button className="btn btn-danger" onClick={logout}>Logout</button>
              </li>
            </ul>
          </nav>
          <hr />
         <p>Your balance {balance}</p>
          <Switch>
            <Route path="/MoneyBoxes/moneyboxes" component={MoneyBoxes} />
          </Switch>
          <Switch>
            <Route path="/Incomes/incomes" component={(props) => <Incomes {...props} getBallance={this.getBallance} />} />
          </Switch>
          <Switch>
            <Route path="/Expenses/expenses" component={Expenses} />
          </Switch>
        </div>
      </Router>
    );
  }
}

export default Dashboard;
