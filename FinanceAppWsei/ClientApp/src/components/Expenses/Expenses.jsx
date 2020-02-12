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
import CategoriesApi from "../../api/categories";
import MoneyBoxesApi from "../../api/moneyBoxes";
class Expenses extends Component {
  state = {
    expenses: [],
    moneyBoxes: [],
    categories: []
  };

  componentDidMount() {
    this.getExpenses();
    this.getMoneyBoxes();
    this.getCategories();
  }

  getMoneyBoxes = () => {
    MoneyBoxesApi.get().then(response => {
      this.setState({
        moneyBoxes: response.data.Data
      });
    });
  };
  getCategories = () => {
    CategoriesApi.get().then(response => {
      this.setState({
        categories: response.data.Data
      });
    });
  };

  getExpenses = () => {
    ExpensesApi.get().then(response => {
      this.setState({
        expenses: response.data.Data
      });
    });
  };

  addExpense = e => {
    e.preventDefault();
    const { title, expenseValue, moneyBox, categoryId } = e.target.elements;
    const { getBallance } = this.props;
    const valueError = document.querySelector(".valueError");

    const ExpensesData = {
      title: title.value,
      categoryId: categoryId.value === "empty" ? null : categoryId.value,
      moneyBoxId: moneyBox.value === "empty" ? null : moneyBox.value,
      value: expenseValue.value
    };

    ExpensesApi.create(ExpensesData)
      .then(this.getExpenses)
      .then(getBallance)
      .catch(err => {
        valueError.innerHTML = `Value ${expenseValue.value} is invalid, please enter a number!`;
      });
  };

  deleteExpense = id => {
    const { getBallance } = this.props;
    ExpensesApi.delete(id)
      .then(this.getExpenses)
      .then(getBallance);
  };

  onChange(e, index) {
    let copyExpenses = [...this.state.expenses];
    copyExpenses[index][e.target.name] =
      e.target.value === "empty" ? null : e.target.value;
    this.setState({ Expenses: copyExpenses });
  }

  editExpense = (e, index, expenseId) => {
    const { expenses } = this.state;
    const { getBallance } = this.props;
    const { Title, Value, MoneyBoxId, CategoryId } = expenses[index];

    ExpensesApi.update(expenseId, Title, Value, MoneyBoxId, CategoryId)
      .then(response => {
        this.setIsEdited(index, false);
      })
      .then(getBallance);
  };

  setIsEdited = (id, flag) => {
    const { expenses } = this.state;
    let copyExpenses = [...expenses];
    copyExpenses[id].isEdited = flag;
    this.setState({ Expenses: copyExpenses });
  };
  render() {
    const { expenses, moneyBoxes, categories } = this.state;

    return (
      <Container className="main-container">
        <h3>Add Expense</h3>
        <Form onSubmit={this.addExpense} className="main-form">
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
              Value
            </Label>
            <Input
              type="text"
              name="expenseValue"
              id="valueExpense"
              placeholder="value"
            />
          </FormGroup>
          <FormGroup>
            <Label for="moneyBoxes">Money Boxes</Label>
            <Input type="select" name="moneyBox" id="moneyBoxes">
              <option value="empty">Empty</option>
              {moneyBoxes.map(moneyBox => (
                <option key={moneyBox.Id} value={moneyBox.Id}>
                  {moneyBox.Title}
                </option>
              ))}
            </Input>
          </FormGroup>
          <FormGroup>
            <Label for="categories">Categories</Label>
            <Input type="select" name="categoryId" id="categories">
              <option value="empty">Empty</option>
              {categories.map(category => (
                <option key={category.Id} value={category.Id}>
                  {category.Title}
                </option>
              ))}
            </Input>
          </FormGroup>
          <Button className="btn btn-success">Submit</Button>
          <p className="valueError"></p>
        </Form>
        <hr />
        <h3>Expenses</h3>
        {expenses.length > 0 && (
          <Table striped className="table-dark table-bordered">
            <thead>
              <tr>
                <th>ID</th>
                <th>Title</th>
                <th>Value</th>
                <th>MoneyBox</th>
                <th>Category</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {expenses.map((expense, index) => {
                const moneyBoxFiltered = moneyBoxes.filter(
                  mb => mb.Id === expense.MoneyBoxId
                )[0];
                const categoryFiltered = categories.filter(
                  cat => cat.Id === expense.CategoryId
                )[0];
                return (
                  <tr key={expense.Id}>
                    <th>{index}</th>
                    <td>
                      {expense.isEdited ? (
                        <Input
                          type="text"
                          name="Title"
                          id="valueEditexpense"
                          placeholder="title"
                          value={expense.Title}
                          onChange={e => this.onChange(e, index)}
                        />
                      ) : (
                        expense.Title
                      )}
                    </td>
                    <td>
                      {expense.isEdited ? (
                        <Input
                          type="text"
                          name="Value"
                          id="valueEditexpense"
                          placeholder="value"
                          value={expense.Value}
                          onChange={e => this.onChange(e, index)}
                        />
                      ) : (
                        `${expense.Value}$`
                      )}
                    </td>
                    <td>
                      {expense.isEdited ? (
                        <Input
                          type="select"
                          name="MoneyBoxId"
                          id="editMoneyBoxes"
                          value={expense.MoneyBoxId}
                          onChange={e => this.onChange(e, index)}
                        >
                          <option value="empty">Empty</option>
                          {moneyBoxes.map(moneyBox => (
                            <option value={moneyBox.Id}>
                              {moneyBox.Title}
                            </option>
                          ))}
                        </Input>
                      ) : moneyBoxFiltered ? (
                        moneyBoxFiltered.Title
                      ) : (
                        ""
                      )}
                    </td>
                    <td>
                      {expense.isEdited ? (
                        <Input
                          type="select"
                          name="CategoryId"
                          id="editCategory"
                          value={expense.CategoryId}
                          onChange={e => this.onChange(e, index)}
                        >
                          <option value="empty">Empty</option>
                          {categories.map(Category => (
                            <option value={Category.Id}>
                              {Category.Title}
                            </option>
                          ))}
                        </Input>
                      ) : categoryFiltered ? (
                        categoryFiltered.Title
                      ) : (
                        ""
                      )}
                    </td>
                    <td>
                      {expense.isEdited ? (
                        <button
                          onClick={e => this.editExpense(e, index, expense.Id)}
                          className="btn btn-danger"
                        >
                          Confirm
                        </button>
                      ) : (
                        <button
                          onClick={() => this.setIsEdited(index, true)}
                          className="btn btn-danger"
                        >
                          Edit
                        </button>
                      )}
                      <button
                        onClick={() => this.deleteExpense(expense.Id)}
                        className="ml-3 btn btn-danger"
                      >
                        Delete
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </Table>
        )}
        <br />
        <br />
      </Container>
    );
  }
}

export default Expenses;
