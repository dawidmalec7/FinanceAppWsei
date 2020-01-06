import React from "react";
import LoginForm from "./LoginForm.jsx";
import RegisterForm from "./RegisterForm.jsx";
import { Col, Row, Container } from "reactstrap";

const LoginPanel = ({ setUserLogged }) => {
  return (
    <div className="login-panel">
      <Container>
        <Row>
          <Col md={6}>
            <h2>ZALOGUJ SIE TUTEJ KURDE FELEK!</h2>
            <LoginForm setUserLogged={setUserLogged} />
          </Col>
          <Col md={6}>
            <h2>A KONTA JAK NIE MOSZ TO TUTEJ SIE REJESTRUJ!</h2>
            <RegisterForm />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default LoginPanel;
