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
import CategoriesApi from "../../api/categories";

class Categories extends Component {
  state = {
    Categories: []
  };

  componentDidMount() {
    this.getCategories();
  }

  getCategories = () => {
    CategoriesApi.get().then(response => {
      this.setState({
        Categories: response.data.Data
      });
    });
  };

  addCategory = e => {
    e.preventDefault();
    const { title } = e.target.elements;

    CategoriesApi.add(title)
      .then(this.getCategories)
      .catch(err => {
        console.error(err);
      });
  };

  deleteCategory = id => {
    CategoriesApi.delete(id).then(this.getCategories);
  };
  render() {
    const { Categories } = this.state;

    return (
      <Container className="main-container">
        <h2>Categories</h2>

        {Categories.length > 0 && (
          <Table striped>
            <thead>
              <tr>
                <th>#</th>
                <th>Title</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {Categories.map((Category, index) => (
                <tr>
                  <th>{index}</th>
                  <td>{Category.Value}</td>
                  <td>
                    <button onClick={() => this.deleteCategory(Category.Id)}>
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        )}

        <h3>Add Category</h3>
        <Form onSubmit={this.addCategory} className="main-form">
          <FormGroup className="mb-2">
            <Label for="titleCategory" className="mr-sm-2">
              Title
            </Label>
            <Input
              type="text"
              name="title"
              id="titleCategory"
              placeholder="Title"
            />
          </FormGroup>
          <Button className="btn btn-success">Submit</Button>
        </Form>
      </Container>
    );
  }
}

export default Categories;
