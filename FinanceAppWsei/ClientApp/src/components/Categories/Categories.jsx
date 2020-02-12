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
    categories: [],
    categoryForm: {
      title: ""
    }
  };

  componentDidMount() {
    this.getCategories();
  }

  getCategories = () => {
    CategoriesApi.get().then(response => {
      this.setState({
        categories: response.data.Data
      });
    });
  };

  addCategory = e => {
    e.preventDefault();
    const { categoryForm } = this.state;

    CategoriesApi.add(categoryForm.title)
      .then(this.getCategories)
      .catch(err => {
        console.error(err);
      });
  };

  onChange(e, index) {
    let copyCategories = [...this.state.categories];
    copyCategories[index][e.target.name] =
      e.target.value === "empty" ? null : e.target.value;
    this.setState({ categories: copyCategories });
  }

  editCategory = (e, index, categoryId) => {
    const { categories } = this.state;
    const { getBallance } = this.props;
    const { Title } = categories[index];

    CategoriesApi.edit(categoryId, Title)
      .then(response => {
        this.setIsEdited(index, false);
      })
      .then(getBallance);
  };

  setIsEdited = (id, flag) => {
    const { categories } = this.state;
    let copyCategories = [...categories];
    copyCategories[id].isEdited = flag;
    this.setState({ categories: copyCategories });
  };

  deleteCategory = id => {
    CategoriesApi.delete(id).then(this.getCategories);
  };
  onChangeTitle = e => {
    this.setState({ categoryForm: { title: e.target.value } });
  };
  render() {
    const { categories, categoryForm } = this.state;

    return (
      <Container className="main-container">
        <h2>Categories</h2>

        {categories.length > 0 && (
          <Table striped>
            <thead>
              <tr>
                <th>#</th>
                <th>Title</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {categories.map((category, index) => (
                <tr key={category.Id}>
                  <th>{index}</th>
                  <td>
                    {category.isEdited ? (
                      <Input
                        type="text"
                        name="Title"
                        id="valueEditCategory"
                        placeholder="title"
                        value={category.Title}
                        onChange={e => this.onChange(e, index)}
                      />
                    ) : (
                      category.Title
                    )}
                  </td>
                  <td>
                    {category.isEdited ? (
                      <button
                        onClick={e => this.editCategory(e, index, category.Id)}
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
                      className="ml-4 btn btn-danger"
                      onClick={() => this.deleteCategory(category.Id)}
                    >
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
              name="titleCategory"
              id="titleCategory"
              placeholder="Title"
              value={categoryForm.title}
              onChange={this.onChangeTitle}
            />
          </FormGroup>
          <Button className="btn btn-success">Submit</Button>
        </Form>
      </Container>
    );
  }
}

export default Categories;
