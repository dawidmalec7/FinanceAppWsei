import axios from "axios";

const Incomes = {
  create: ({title, value, categoryId, moneyBoxId}) => {
    return axios.post(`${hostName}/incomes/create-income`, {
        "Title": title,
        "CategoryId": categoryId,
        "MoneyBoxId": moneyBoxId,
        "Value": value
    });
  },
  get: () => {
      return axios.get(`${hostName}/incomes/get-incomes`);
  },
  update: ({id, title, categoryId, value}) => {
      return axios.put(`${hostName}/incomes/${id}`, {
        "Title": title,
        "CategoryId": categoryId,
        "Value": value
      });
  },
  delete: (id) => {
      return axios.delete(`${hostName}/incomes/${id}`)
  },

};

export default Incomes;