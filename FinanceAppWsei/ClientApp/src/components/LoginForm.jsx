import React from "react";
import Users from "../api/users";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";
import cookie from "react-cookies";
import axios from "axios";
const LoginForm = ({ setUserLogged }) => {
  const onSubmitForm = e => {
    e.preventDefault();
    const { login, password } = e.target.elements;
    const loginVal = login.value;
    const passwordVal = password.value;
    const loginError = document.querySelector(".loginError");

    Users.login(loginVal, passwordVal)
      .then(resp => {
        cookie.save("AccessToken", resp.data.Data.AccessToken, { path: "/" });
        setUserLogged(true);
        setAuthData();
      })
      .catch(err => {
        setUserLogged(false);
        loginError.innerHTML = "Invalid username or password!";
      });
  };
  const setAuthData = () => {
    return (axios.defaults.headers.common = {
      Authorization: "bearer " + cookie.load("AccessToken")
    });
  };

  return (
    <Form onSubmit={onSubmitForm}>
      <h2>Sign In</h2>
      <FormGroup className="mb-2">
        <Label for="loginForm" className="mr-sm-2">
          Login
        </Label>
        <Input type="text" name="login" id="loginForm" placeholder="Login" />
      </FormGroup>
      <FormGroup className="mb-2">
        <Label for="pass" className="mr-sm-2">
          Password
        </Label>
        <Input
          type="password"
          name="password"
          id="pass"
          placeholder="Password"
        />
      </FormGroup>
      <Button className="btn btn-success">Submit</Button>
      <p class="loginError"></p>
    </Form>
  );
};

export default LoginForm;
