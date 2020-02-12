import axios from "axios";
import hostName from "./default";

const MoneyBoxes = {
  add: ({
    title,
    target,
    value
  }) => {
    return axios.post(`${hostName}/moneyboxes`, {
      "Title": title,
      "Target": target,
      "Value": value
    });
  },
  get: () => {
    return axios.get(`${hostName}/moneyboxes`);
  },
  edit: (
    id,
    title,
    target
  ) => {
    return axios.put(`${hostName}/moneyboxes/${id}`, {
      "Title": title,
      "Target": target
    });
  },
  delete: (id) => {
    return axios.delete(`${hostName}/moneyboxes/${id}`)
  },

};

export default MoneyBoxes;