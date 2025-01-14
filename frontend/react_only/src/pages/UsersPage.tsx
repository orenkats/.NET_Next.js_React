import React, { useState } from "react";
import useFetchUsers from "../hooks/useFetchUsers";
import UserCard from "../components/UserCard";
import Pagination from "../components/Pagination";

const UsersPage: React.FC = () => {
  const [currentPage, setCurrentPage] = useState(1); // State for current page
  const usersPerPage = 10; // Number of users per page

  // Fetch users based on the current page
  const { data, isLoading, error } = useFetchUsers(currentPage, usersPerPage);

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  // Calculate total pages from the API response
  const totalPages = 5; 
  console.log(data?.info.results); // Should log the total number of users

  return (
    <div>
      <h1>Users</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
        {data?.results.map((user, index) => (
          <UserCard key={index} user={user} />
        ))}
      </div>

      {/* Pass currentPage, totalPages, and setCurrentPage to Pagination */}
      <Pagination
        currentPage={currentPage}
        totalPages={totalPages}
        onPageChange={(page) => setCurrentPage(page)}
      />
    </div>
  );
};

export default UsersPage;
