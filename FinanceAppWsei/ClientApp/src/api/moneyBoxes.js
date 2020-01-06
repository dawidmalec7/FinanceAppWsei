import axios from "axios";
import hostName from "./default";

const MoneyBoxes = {
  add: ({title, target, value}) => {
    return axios.post(`${hostName}/money-boxes/add-new-money-box`, {
        "Title": title,
        "Target": target,
        "Value": value
    });
  },
  get: () => {
      return axios.get(`${hostName}/money-boxes/get-money-boxes`);
  },
  edit: ({id, title, target}) => {
      return axios.put(`${hostName}/money-boxes/${id}`, {
        "Title": title,
        "Target": target
      });
  },
  delete: (id) => {
      return axios.delete(`${hostName}/money-boxes/${id}`)
  },

};

export default MoneyBoxes;