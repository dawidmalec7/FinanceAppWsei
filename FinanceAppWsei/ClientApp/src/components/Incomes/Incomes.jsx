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
import "./Incomes.css";
import IncomesApi from "../../api/incomes";
import AccountsApi from "../../api/accounts";
import MoneyBoxesApi from "../../api/moneyBoxes";
class Incomes extends Component {
  state = {
    incomes: [],
    moneyBoxes: []
  };

  componentDidMount() {
    this.getIncomes();
    this.getMoneyBoxes();
  }

  getIncomes = () => {
    IncomesApi.get().then(response => {
      this.setState({
        incomes: response.data.Data
      });
    });
  };

  addIncome = e => {
    e.preventDefault();
    const { title, incomeValue, moneyBox } = e.target.elements;
    const { getBallance } = this.props;

    const IncomesData = {
      title: title.value,
      CategoryId: "",
      MoneyBoxId: moneyBox.value,
      value: incomeValue.value
    };

    IncomesApi.create(IncomesData)
      .then(this.getIncomes)
      .then(getBallance)
      .catch(err => {
        console.error(err);
      });
  };

  deleteIncome = id => {
    const { getBallance } = this.props;
    IncomesApi.delete(id)
      .then(this.getIncomes)
      .then(getBallance);
  };

  getMoneyBoxes = () => {
    MoneyBoxesApi.get().then(response => {
      this.setState({
        moneyBoxes: response.data.Data
      });
    });
  };
  render() {
    const { incomes, moneyBoxes } = this.state;

    return (
      <Container>
        <h3>Add Income</h3>
        <Form onSubmit={this.addIncome}>
          <FormGroup className="mb-2">
            <Label for="titleIncome" className="mr-sm-2">
              Title
            </Label>
            <Input
              type="text"
              name="title"
              id="titleIncome"
              placeholder="Title"
            />
          </FormGroup>
          <FormGroup className="mb-2">
            <Label for="valueIncome" className="mr-sm-2">
              value
            </Label>
            <Input
              type="text"
              name="incomeValue"
              id="valueIncome"
              placeholder="value"
            />
          </FormGroup>
          <FormGroup>
            <Label for="moneyBoxes">Money Boxes</Label>
            <Input type="select" name="moneyBox" id="moneyBoxes">
              {moneyBoxes.map(moneyBox => (
                <option value={moneyBox.Id}>{moneyBox.Title}</option>
              ))}
            </Input>
          </FormGroup>
          <Button className="btn btn-success">Submit</Button>
        </Form>
        <hr />
        <h3>Incomes</h3>
        {incomes.length > 0 && (
          <Table striped className="table-dark table-bordered">
            <thead>
              <tr>
                <th>ID</th>
                <th>Title</th>
                <th>Value</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {incomes.map((income, index) => (
                <tr>
                  <th>{index}</th>
                  <td>{income.Title}</td>
                  <td>{income.Value}</td>
                  <td>
                    <button onClick={() => this.deleteIncome(income.Id)} className="btn btn-danger">
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )}
        <br /><br />
      </Container>
    );
  }
}

export default Incomes;
