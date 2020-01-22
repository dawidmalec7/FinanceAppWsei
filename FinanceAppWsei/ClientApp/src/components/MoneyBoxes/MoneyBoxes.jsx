import React, { Component } from "react";
import {
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  Table,
  Container
} from "reactstrap";
import MoneyBoxesApi from "../../api/moneyBoxes";
class MoneyBoxes extends Component {
  state = {
    moneyBoxes: []
  };

  componentDidMount() {
    this.getMoneyBoxes();
  }

  getMoneyBoxes = () => {
    MoneyBoxesApi.get().then(response => {
      this.setState({
        moneyBoxes: response.data.Data
      });
    });
  };

  addMoneyBox = e => {
    e.preventDefault();
    const { titleMoneyBox, targetMoneyBox, valueMoneyBox } = e.target.elements;

    const moneyBoxesData = {
      title: titleMoneyBox.value,
      target: targetMoneyBox.value,
      value: valueMoneyBox.value
    };

    MoneyBoxesApi.add(moneyBoxesData)
      .then(this.getMoneyBoxes)
      .then(this.getMoneyBoxes)
      .catch(err => {
        console.error(err);
      });
  };

  deleteMoneyBox = id => {
    MoneyBoxesApi.delete(id).then(this.getmoneyBoxes);
  };
  render() {
    const { moneyBoxes } = this.state;

    return (
      <Container className="main-container">
        <h2>MoneyBoxes</h2>

        {moneyBoxes.length > 0 && (
          <Table striped>
            <thead>
              <tr>
                <th>#</th>
                <th>Title</th>
                <th>Value</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {moneyBoxes.map((moneyBox, index) => (
                <tr>
                  <th>{index}</th>
                  <td>{moneyBox.Title}</td>
                  <td>{moneyBox.Value}</td>
                  <td>
                    <button onClick={() => this.deleteMoneyBox(moneyBox.Id)}>
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )}

        <h3>Add Your Target</h3>
        <Form onSubmit={this.addMoneyBox} className="main-form">
          <FormGroup className="mb-2">
            <Label for="titleMoneyBox" className="mr-sm-2">
              Title
            </Label>
            <Input
              type="text"
              name="titleMoneyBox"
              id="titleMoneyBox"
              placeholder="Title"
            />
          </FormGroup>
          <FormGroup className="mb-2">
            <Label for="targetMoneyBox" className="mr-sm-2">
              Target
            </Label>
            <Input
              type="text"
              name="target"
              id="targetMoneyBox"
              placeholder="Target"
            />
          </FormGroup>
          <FormGroup className="mb-2">
            <Label for="valueMoneyBox" className="mr-sm-2">
              Cash
            </Label>
            <Input
              type="text"
              name="incomeValue"
              id="valueMoneyBox"
              placeholder="value"
            />
          </FormGroup>
          <Button className="btn btn-success">Submit</Button>
        </Form>
      </Container>
    );
  }
}

export default MoneyBoxes;
