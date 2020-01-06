import axios from "axios";
import hostName from "./default";

const Users = {
  login: (login, password) => {
    return axios.post(`${hostName}/users/login`, {
        "Login": login,
        "Password": password
    });
  },
  register: ({firstName, lastName, login, password}) => {
    return axios.post(`${hostName}/users/register`, {
      "FirstName": firstName,
      "LastName": lastName,
      "Login": login,
      "Password": password
    });
  }
};

export default Users;