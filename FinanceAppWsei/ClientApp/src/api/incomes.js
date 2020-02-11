import axios from "axios";
import hostName from "./default";

const Incomes = {
  create: ({
    title,
    value,
    categoryId,
    moneyBoxId
  }) => {
    return axios.post(`${hostName}/incomes`, {
      "Title": title,
      "CategoryId": categoryId,
      "MoneyBoxId": moneyBoxId,
      "Value": value
    });
  },
  get: () => {
    return axios.get(`${hostName}/incomes`);
  },
  update: (
    id,
    title,
    value,
    moneyBoxId = null,
    categoryId = null
  ) => {
    return axios.put(`${hostName}/incomes/${id}`, {
      "Title": title,
      "CategoryId": categoryId,
      "MoneyBoxId": moneyBoxId,
      "Value": value
    });
  },
  delete: (id) => {
    return axios.delete(`${hostName}/incomes/${id}`)
  },

};

export default Incomes;