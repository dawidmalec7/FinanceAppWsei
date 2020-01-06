import axios from "axios";
import hostName from "./default";

const Accounts = {
  get: () => {
      return axios.get(`${hostName}/accounts/get-account-balance`);
  }
};

export default Accounts;