import React from 'react';
import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import LoginForm from "./components/LoginForm.jsx";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <LoginForm /> 
      </header>
    </div>
  );
}

export default App;
