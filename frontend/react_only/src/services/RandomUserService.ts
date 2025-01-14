import api from "./api";
import { RandomUserResponse } from "../types/User";

/**
 * Fetches random user data from the API.
 * @returns {Promise<RandomUserResponse>} A promise resolving to the API response.
 */
export const fetchRandomUser = async (): Promise<RandomUserResponse> => {
  const response = await api.get(""); // Axios automatically parses JSON
  return response.data; // Return the response data
};
