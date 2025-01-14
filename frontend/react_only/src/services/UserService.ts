import api from "./api";
import { UserResponse , User} from "../types/User";

export const fetchUsers = async (page: number, pageSize: number): Promise<UserResponse> => {
  const response = await api.get(`/users?page=${page}&pageSize=${pageSize}`);
  return response.data;
};

// Optional: Add more functions for searching and fetching user details
export const searchUsers = async (query: string): Promise<UserResponse> => {
  const response = await api.get(`/users/search?query=${query}`);
  return response.data;
};

export const getUserById = async (id: string): Promise<User> => {
  const response = await api.get(`/users/${id}`);
  return response.data;
};
