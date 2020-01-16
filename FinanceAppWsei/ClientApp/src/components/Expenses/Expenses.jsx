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
import ExpensesApi from "../../api/expenses";
import AccountsApi from "../../api/accounts";
class Expenses extends Component {
  state = {
    expenses: []
  };

  componentDidMount() {
    this.getExpenses();
  }

  getExpenses = () => {
    ExpensesApi.get().then(response => {
      this.setState({
        expenses: response.data.Data
      });
    });
  };

  addExpense = e => {
    e.preventDefault();
    const { title, expenseValue } = e.target.elements;
    const { getBallance } = this.props;

    const ExpensesData = {
      title: title.value,
      CategoryId: "",
      MoneyBoxId: "",
      value: expenseValue.value
    };

    ExpensesApi.create(ExpensesData)
      .then(this.getExpenses)
      .then(getBallance)
      .catch(err => {
        console.error(err);
      });
  };

  deleteExpense = id => {
    const { getBallance } = this.props;
    ExpensesApi.delete(id)
      .then(this.getExpenses)
      .then(getBallance);
  };
  render() {
    const { expenses } = this.state;

    return (
      <Container>
        <h2>Expenses</h2>

        {expenses.length > 0 && (
          <Table striped>
            <thead>
              <tr>
                <th>ID</th>
                <th>Title</th>
                <th>Value</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {expenses.map((expense, index) => (
                <tr>
                  <th>{index}</th>
                  <td>{expense.Title}</td>
                  <td>{expense.Value}</td>
                  <td>
                    <button onClick={() => this.deleteExpense(expense.Id)}>
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )}

        <h3>Add Expense</h3>
        <Form onSubmit={this.addExpense}>
          <FormGroup className="mb-2">
            <Label for="titleExpense" className="mr-sm-2">
              Title
            </Label>
            <Input
              type="text"
              name="title"
              id="titleExpense"
              placeholder="Title"
            />
          </FormGroup>
          <FormGroup className="mb-2">
            <Label for="valueExpense" className="mr-sm-2">
              value
            </Label>
            <Input
              type="text"
              name="expenseValue"
              id="valueExpense"
              placeholder="value"
            />
          </FormGroup>
          <Button>Submit</Button>
        </Form>
      </Container>
    );
  }
}

export default Expenses;
