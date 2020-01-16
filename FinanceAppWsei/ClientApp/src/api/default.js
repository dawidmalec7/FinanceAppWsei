import axios from "axios";
import cookie from 'react-cookies';

const hostName = "https://localhost:5001/api";

(
  () =>
  (axios.defaults.headers.common = {
    'Authorization': "bearer " + cookie.load("AccessToken")
  })
)();

export default hostName;