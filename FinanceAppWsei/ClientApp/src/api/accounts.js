import axios from "axios";
import hostName from "./default";

const Accounts = {
  get: () => {
      return axios.get(`${hostName}/accounts`);
  }
};

export default Accounts;