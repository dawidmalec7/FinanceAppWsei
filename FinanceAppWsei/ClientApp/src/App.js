import React, { Component } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import LoginPanel from "./components/LoginPanel";
import cookie from 'react-cookies';
import Dashboard from "./components/Dashboard";
import { withRouter } from 'react-router-dom';

class App extends Component {
  state = {
    userLogged: false
  }

  componentWillMount() {
    this.setState({
      userLogged: cookie.load('AccessToken') ? true : false
    })
  }
  setUserLogged = (logged) => {
    this.setState({ userLogged: logged })
  }

  logout = () => {
    cookie.remove('AccessToken');
    this.props.history.push('/');
    this.setState({ userLogged: false });
  }
  render(){
    const { userLogged } = this.state;
    return (
        <div className="App">
            { userLogged 
            ? <Dashboard logout={this.logout}/>
            : <LoginPanel 
                setUserLogged={this.setUserLogged} 
              />
            }
        </div>
      );
    }
}

export default withRouter(App);
