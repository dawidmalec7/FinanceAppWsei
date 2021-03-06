import axios from "axios";
import hostName from "./default";

const Expenses = {
  create: ({
    title,
    value,
    categoryId,
    moneyBoxId
  }) => {
    return axios.post(`${hostName}/expenses`, {
      "Title": title,
      "CategoryId": categoryId,
      "MoneyBoxId": moneyBoxId,
      "Value": value
    });
  },
  get: () => {
    return axios.get(`${hostName}/expenses`);
  },
  update: (
    id,
    title,
    value,
    moneyBoxId = null,
    categoryId = null) => {
    return axios.put(`${hostName}/expenses/${id}`, {
      "Title": title,
      "CategoryId": categoryId,
      "MoneyBoxId": moneyBoxId,
      "Value": value
    });
  },
  delete: (id) => {
    return axios.delete(`${hostName}/expenses/${id}`)
  },

};

export default Expenses;