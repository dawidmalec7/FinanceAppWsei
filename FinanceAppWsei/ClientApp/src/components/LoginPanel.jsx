import React from "react";
import LoginForm from "./LoginForm.jsx";
import RegisterForm from "./RegisterForm.jsx";
import { Col, Row, Container } from "reactstrap";

const LoginPanel = ({ setUserLogged, userLogged }) => {
  return (
    <div className="login-panel">
      <Container>
        <Row className="login-form">
          <Col md={4}></Col>
          <Col md={4}>
            <LoginForm setUserLogged={setUserLogged} />
          </Col>
          <Col md={4}></Col>
        </Row>
        
        <Row className="register-form">
          <Col md={2}></Col>
          <Col md={8}>
            <RegisterForm />
          </Col>
          <Col md={2}></Col>
        </Row>
      </Container>
    </div>
  );
};

export default LoginPanel;
