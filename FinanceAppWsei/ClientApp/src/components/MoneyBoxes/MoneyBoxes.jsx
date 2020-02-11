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
    const { titleMoneyBox, targetMoneyBox } = e.target.elements;

    const moneyBoxesData = {
      title: titleMoneyBox.value,
      target: targetMoneyBox.value
    };

    MoneyBoxesApi.add(moneyBoxesData)
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
    console.log(this.state);
    return (
      <Container className="main-container">
        <h2>MoneyBoxes</h2>

        {moneyBoxes.length > 0 && (
          <Table striped>
            <thead>
              <tr>
                <th>#</th>
                <th>Title</th>
                <th>Target</th>
                <th>Cash</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {moneyBoxes.map((moneyBox, index) => (
                <tr>
                  <th>{index}</th>
                  <td>{moneyBox.Title}</td>
                  <td>{moneyBox.Target}</td>
                  <td>
                    {parseInt(moneyBox.Target) + parseInt(moneyBox.Value)}
                  </td>
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
          <Button className="btn btn-success">Submit</Button>
        </Form>
      </Container>
    );
  }
}

export default MoneyBoxes;
