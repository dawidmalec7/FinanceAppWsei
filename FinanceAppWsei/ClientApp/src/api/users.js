import axios from "axios";

const Users = {
  login: (login, password) => {
    return axios.post('api/login', {
        "Login": login,
        "Password": password
    });
  },
  register: ({firstName, lastName, login, password}) => {
    return axios.post('api/register', {
      "FirstName": firstName,
      "LastName": lastName,
      "Login": login,
      "Password": password
    });
  }
};

export default Users;