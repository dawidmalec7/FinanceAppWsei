import axios from "axios";
import hostName from "./default";

const Categories = {
  add: (title) => {
    return axios.post(`${hostName}/categories`, {
      "Title": title,
    });
  },
  get: () => {
    return axios.get(`${hostName}/categories`);
  },
  edit: (
    id,
    title
  ) => {
    return axios.put(`${hostName}/categories/${id}`, {
      "Title": title
    });
  },
  delete: (id) => {
    return axios.delete(`${hostName}/categories/${id}`)
  },

};

export default Categories;