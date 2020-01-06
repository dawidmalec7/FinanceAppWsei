import axios from "axios";

const Users = {
  login: (login, password) => {
    return axios.post('api/login', {
        "Login": login,
        "Password": password
    });
  },
};

export default Users;