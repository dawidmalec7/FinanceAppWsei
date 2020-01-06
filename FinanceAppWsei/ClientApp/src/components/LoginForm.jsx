import React from "react";
import Users from "../api/users";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import cookie from 'react-cookies';
const LoginForm = ({setUserLogged}) =>{

  const onSubmitForm = (e) => {
    e.preventDefault();
    const {login, password } = e.target.elements;
    const loginVal = login.value;
    const passwordVal = password.value;

    Users.login(loginVal, passwordVal)
    .then(resp => {
      cookie.save("AccessToken", resp.data.Data.AccessToken, { path: '/' });
      setUserLogged(true);
    })
    .catch(err =>{
      console.error(err);
      setUserLogged(false);
    })
  }

  return (
    <Form onSubmit={onSubmitForm}>
      <FormGroup className="mb-2">
        <Label for="loginForm" className="mr-sm-2">Login</Label>
        <Input type="text" name="login" id="loginForm" placeholder="Login" />
      </FormGroup>
      <FormGroup className="mb-2">
        <Label for="pass" className="mr-sm-2">Password</Label>
        <Input type="password" name="password" id="pass" placeholder="Password" />
      </FormGroup>
      <Button>Submit</Button>
    </Form>
  );
}

export default LoginForm;
