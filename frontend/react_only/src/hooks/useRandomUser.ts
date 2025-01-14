import { useQuery } from "@tanstack/react-query";
import { fetchRandomUser } from "../services/RandomUserService";
import { RandomUserResponse } from "../types/RandomUserTypes";

/**
 * Custom hook to fetch random user data using React Query.
 * @returns {object} React Query's data, error, and loading states.
 */
const useRandomUser = () => {
  return useQuery<RandomUserResponse, Error>({
    queryKey: ["randomUser"], // Unique key for this query
    queryFn: fetchRandomUser, // Axios fetch function
  });
};

export default useRandomUser;
