import React, { useState } from "react";
import { Col, Row, Button, Form, FormGroup, Label, Input } from "reactstrap";
import Users from "../api/users";

const RegisterForm = () => {
  const [registerComplete, setRegisterComplete] = useState(false);
  const onSubmitForm = e => {
    e.preventDefault();
    const { login, password, firstName, lastName } = e.target.elements;
    const registerValues = {
      login: login.value,
      password: password.value,
      firstName: firstName.value,
      lastName: lastName.value
    };
    const registerError = document.querySelector(".registerError");

    Users.register(registerValues)
      .then(resp => {
        setRegisterComplete(true);
      })
      .catch(err => {
        registerError.innerHTML = "The user is already in the database, please log in!";
      });
  };

  return (
    <>
      {registerComplete ? (
        <>
          <p>Rejestracja przebiegła pomyślnie! Zaloguj sie obok!</p>
        </>
      ) : (
        <Form onSubmit={onSubmitForm}>
        <h2>Register</h2>
          <Row form>
            <Col md={6}>
              <FormGroup>
                <Label for="Login">Login</Label>
                <Input
                  type="text"
                  name="login"
                  id="Login"
                  placeholder="Login"
                />
              </FormGroup>
            </Col>
            <Col md={6}>
              <FormGroup>
                <Label for="Password">Password</Label>
                <Input
                  type="password"
                  name="password"
                  id="password"
                  placeholder="Password"
                />
              </FormGroup>
            </Col>
          </Row>
          <Row form>
            <Col md={6}>
              <FormGroup>
                <Label for="FirstName">First Name</Label>
                <Input
                  type="text"
                  name="firstName"
                  id="FirstName"
                  placeholder="First Name"
                />
              </FormGroup>
            </Col>
            <Col md={6}>
              <FormGroup>
                <Label for="LastName">Last Name</Label>
                <Input
                  type="text"
                  name="lastName"
                  id="LastName"
                  placeholder="Last Name"
                />
              </FormGroup>
            </Col>
          </Row>
          <Button className="btn btn-success" id='sign-in'>Sign in</Button>
          <p className="registerError">  </p>
        </Form>
      )}
    </>
  );
};

export default RegisterForm;
