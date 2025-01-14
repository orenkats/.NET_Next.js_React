import { useQuery } from "@tanstack/react-query";
import { fetchUsers } from "../services/UserService";
import { UserResponse } from "../types/User";

const useFetchUsers = (page: number, pageSize: number) => {
  return useQuery<UserResponse, Error>({
    queryKey: ["users", page, pageSize],
    queryFn: () => fetchUsers(page, pageSize),
  });
};

export default useFetchUsers;
