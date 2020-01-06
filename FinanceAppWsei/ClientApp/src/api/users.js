import axios from "axios";
import hostName from "./default";

const Users = {
  login: (login, password) => {
    return axios.post(`${hostName}/users/login`, {
        "Login": login,
        "Password": password
    });
  },
};

export default Users;