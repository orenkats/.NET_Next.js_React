import { useQuery } from "@tanstack/react-query";
import { fetchUsers } from "../services/UserService";
import { UserResponse } from "../types/User";

const useFetchUsers = (page: number, results: number) => {
  return useQuery<UserResponse, Error>({
    queryKey: ["users", page, results],
    queryFn: () => fetchUsers(page, results),
    //keepPreviousData: true,  // Ensures the cached data is retained between page changes
  });
};

export default useFetchUsers;
