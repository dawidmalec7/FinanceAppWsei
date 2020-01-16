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
import AccountsApi from "../../api/accounts";
class Incomes extends Component {
  state = {
    incomes: []
  };

  componentDidMount() {
    this.getIncomes();
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
    const { title, incomeValue } = e.target.elements;
    const { getBallance } = this.props;

    const IncomesData = {
      title: title.value,
      CategoryId: "",
      MoneyBoxId: "",
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
  render() {
    const { incomes } = this.state;

    return (
      <Container>
        <h2>Incomes</h2>

        {incomes.length > 0 && (
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
              {incomes.map((income, index) => (
                <tr>
                  <th>{index}</th>
                  <td>{income.Title}</td>
                  <td>{income.Value}</td>
                  <td>
                    <button onClick={() => this.deleteIncome(income.Id)}>
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )}

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
          <Button>Submit</Button>
        </Form>
      </Container>
    );
  }
}

export default Incomes;
