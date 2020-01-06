import axios from "axios";

const Accounts = {
  get: () => {
      return axios.get(`${hostName}/accounts/get-account-balance`);
  }
};

export default Accounts;