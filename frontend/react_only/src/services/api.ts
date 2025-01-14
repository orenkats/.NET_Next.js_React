import axios from "axios";

// Create an Axios instance
const api = axios.create({
  baseURL: "https://randomuser.me/api/", // Set the base URL for all requests
  timeout: 5000, // Optional: Set a timeout for requests
  headers: {
    "Content-Type": "application/json",
  },
});

export default api;
