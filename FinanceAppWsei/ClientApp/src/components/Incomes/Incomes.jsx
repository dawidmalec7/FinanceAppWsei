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
import IncomesApi from "../../api/incomes";
import CategoriesApi from "../../api/categories";
import MoneyBoxesApi from "../../api/moneyBoxes";
class Incomes extends Component {
  state = {
    incomes: [],
    moneyBoxes: [],
    categories: []
  };

  componentDidMount() {
    this.getIncomes();
    this.getMoneyBoxes();
    this.getCategories();
  }

  getCategories = () => {
    CategoriesApi.get().then(response => {
      this.setState({
        categories: response.data.Data
      });
    });
  };

  getIncomes = () => {
    IncomesApi.get().then(response => {
      this.setState({
        incomes: response.data.Data
      });
    });
  };

  addIncome = e => {
    e.preventDefault();
    const { title, incomeValue, moneyBox, categoryId } = e.target.elements;
    const { getBallance } = this.props;
    const valueError = document.querySelector(".valueError");

    const IncomesData = {
      title: title.value,
      categoryId: categoryId.value === "empty" ? null : categoryId.value,
      moneyBoxId: moneyBox.value === "empty" ? null : moneyBox.value,
      value: incomeValue.value
    };
    IncomesApi.create(IncomesData)
      .then(this.getIncomes)
      .then(getBallance)
      .catch(err => {
        valueError.innerHTML = `Value ${incomeValue.value} is invalid, please enter a number!`;
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

  onChange(e, index) {
    let copyIncomes = [...this.state.incomes];
    copyIncomes[index][e.target.name] =
      e.target.value === "empty" ? null : e.target.value;
    this.setState({ incomes: copyIncomes });
  }

  editIncome = (e, index, incomeId) => {
    const { incomes } = this.state;
    const { getBallance } = this.props;
    const { Title, Value, MoneyBoxId, CategoryId } = incomes[index];

    IncomesApi.update(incomeId, Title, Value, MoneyBoxId, CategoryId)
      .then(response => {
        this.setIsEdited(index, false);
      })
      .then(getBallance);
  };

  setIsEdited = (id, flag) => {
    const { incomes } = this.state;
    let copyIncomes = [...incomes];
    copyIncomes[id].isEdited = flag;
    this.setState({ incomes: copyIncomes });
  };
  render() {
    const { incomes, moneyBoxes, categories } = this.state;
    return (
      <Container className="main-container">
        <h3>Add Income</h3>
        <Form onSubmit={this.addIncome} className="main-form">
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
              Value
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

        <h3>Incomes</h3>
        {incomes.length > 0 && (
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
              {incomes.map((income, index) => {
                const moneyBoxFiltered = moneyBoxes.filter(
                  mb => mb.Id === income.MoneyBoxId
                )[0];
                const categoryFiltered = categories.filter(
                  cat => cat.Id === income.CategoryId
                )[0];
                return (
                  <tr key={income.Id}>
                    <th>{index}</th>
                    <td>
                      {income.isEdited ? (
                        <Input
                          type="text"
                          name="Title"
                          id="valueEditIncome"
                          placeholder="title"
                          value={income.Title}
                          onChange={e => this.onChange(e, index)}
                        />
                      ) : (
                        income.Title
                      )}
                    </td>
                    <td>
                      {income.isEdited ? (
                        <Input
                          type="text"
                          name="Value"
                          id="valueEditIncome"
                          placeholder="value"
                          value={income.Value}
                          onChange={e => this.onChange(e, index)}
                        />
                      ) : (
                        `${income.Value}$`
                      )}
                    </td>
                    <td>
                      {income.isEdited ? (
                        <Input
                          type="select"
                          name="MoneyBoxId"
                          id="editMoneyBoxes"
                          value={income.MoneyBoxId}
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
                      {income.isEdited ? (
                        <Input
                          type="select"
                          name="CategoryId"
                          id="editCategory"
                          value={income.CategoryId}
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
                      {income.isEdited ? (
                        <button
                          onClick={e => this.editIncome(e, index, income.Id)}
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
                        onClick={() => this.deleteIncome(income.Id)}
                        className="ml-4 btn btn-danger"
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
      </Container>
    );
  }
}

export default Incomes;
