import React, { Component } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import LoginPanel from "./components/LoginPanel";
import cookie from 'react-cookies';

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
  render(){
    const { userLogged } = this.state;
    return (
        <div className="App">
          <header className="App-header">
            { userLogged 
            ? "Siema" 
            : <LoginPanel setUserLogged={this.setUserLogged} />
            }
          </header>

        </div>
      );
    }
}

export default App;
