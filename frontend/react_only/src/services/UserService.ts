// services/UserService.ts
import api from "./api";
import { UserResponse } from "../types/User";

export const fetchUsers = async (page: number, results: number): Promise<UserResponse> => {
  const response = await api.get(`?page=${page}&results=${results}`);
  return response.data;
};
