import axios from "axios";

// Create an Axios instance
const api = axios.create({
  baseURL: "http://localhost:5175/api", // Updated to backend API
  timeout: 5000, // Optional: Set a timeout for requests
  headers: {
    "Content-Type": "application/json",
  },
});

export default api;
