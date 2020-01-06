import React from "react";
import Users from "../api/users";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

const LoginForm = (props) =>{

  const onSubmitForm = (e) => {
    e.preventDefault();
    console.log(e.target.elements.login.value);
  }

  return (
    <Form onSubmit={onSubmitForm}>
      <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
        <Label for="loginForm" className="mr-sm-2">Login</Label>
        <Input type="text" name="login" id="loginForm" placeholder="Login" />
      </FormGroup>
      <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
        <Label for="pass" className="mr-sm-2">Password</Label>
        <Input type="password" name="password" id="pass" placeholder="Password" />
      </FormGroup>
      <Button>Submit</Button>
    </Form>
  );
}

export default LoginForm;
