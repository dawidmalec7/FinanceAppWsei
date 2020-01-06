import axios from "axios";

const hostName = "https://localhost:5001/api";
// (
//   () =>
//   (axios.defaults.headers.common = {
//     "X-Requested-With": "XMLHttpRequest",
//     "X-CSRF-Token": document
//       .querySelector('meta[name="csrf-token"]')
//       .getAttribute("content")
//   })
// )();

export default hostName;