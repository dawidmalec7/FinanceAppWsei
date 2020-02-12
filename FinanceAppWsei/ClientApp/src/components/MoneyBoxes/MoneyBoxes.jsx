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
    MoneyBoxesApi.delete(id).then(this.getMoneyBoxes);
  };

  onChange(e, index) {
    let copyMoneyBoxes = [...this.state.moneyBoxes];
    copyMoneyBoxes[index][e.target.name] =
      e.target.value === "empty" ? null : e.target.value;
    this.setState({ moneyBoxes: copyMoneyBoxes });
  }

  editMoneyBox = (e, index, moneyBoxId) => {
    const { moneyBoxes } = this.state;
    const { Title, Target } = moneyBoxes[index];

    MoneyBoxesApi.edit(moneyBoxId, Title, Target)
      .then(response => {
        this.setIsEdited(index, false);
      })
      .then(this.getMoneyBoxes);
  };

  setIsEdited = (id, flag) => {
    const { moneyBoxes } = this.state;
    let copyMoneyBoxes = [...moneyBoxes];
    copyMoneyBoxes[id].isEdited = flag;
    this.setState({ moneyBoxes: copyMoneyBoxes });
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
                <th>Target</th>
                <th>Cash</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {moneyBoxes.map((moneyBox, index) => (
                <tr key={moneyBox.Id}>
                  <th>{index}</th>
                  <td>
                    {moneyBox.isEdited ? (
                      <Input
                        type="text"
                        name="Title"
                        id="valueEditmoneyBox"
                        placeholder="title"
                        value={moneyBox.Title}
                        onChange={e => this.onChange(e, index)}
                      />
                    ) : (
                      moneyBox.Title
                    )}
                  </td>
                  <td>
                    {moneyBox.isEdited ? (
                      <Input
                        type="text"
                        name="Target"
                        id="valueEditmoneyBox"
                        placeholder="value"
                        value={moneyBox.Target}
                        onChange={e => this.onChange(e, index)}
                      />
                    ) : (
                      `${moneyBox.Target}$`
                    )}
                  </td>
                  <td>{parseInt(-moneyBox.Value)}$</td>
                  <td>
                    {moneyBox.isEdited ? (
                      <button
                        onClick={e => this.editMoneyBox(e, index, moneyBox.Id)}
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
                    {/* <button onClick={() => this.deleteMoneyBox(moneyBox.Id)}>
                      Delete
                    </button> */}
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
