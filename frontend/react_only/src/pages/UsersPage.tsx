import React, { useState } from "react";
import useFetchUsers from "../hooks/useFetchUsers";
import UserCard from "../components/UserCard";
import Pagination from "../components/Pagination";
import styles from "./UsersPage.module.scss"; 

const UsersPage: React.FC = () => {
  const [currentPage, setCurrentPage] = useState(1); // State for current page
  const usersPerPage = 10; // Number of users per page

  // Fetch users based on the current page
  const { data, isLoading, error } = useFetchUsers(currentPage, usersPerPage);

  if (isLoading) return <p className={styles.message}>Loading...</p>;
  if (error) return <p className={styles.message}>Error: {error.message}</p>;
  if (!data?.info?.totalCount) {
    return <p className={styles.message}>No data available</p>;
  }

  // Calculate total pages from the API response
  const totalPages = Math.ceil(data.info.totalCount / usersPerPage);

  return (
    <div className={styles.pageContainer}>
      <h1 className={styles.pageTitle}>Users</h1>
      <div className={styles.usersGrid}>
        {data.results.map((user, index) => (
          <UserCard key={index} user={user} />
        ))}
      </div>
      <Pagination
        currentPage={currentPage}
        totalPages={totalPages}
        onPageChange={(page) => setCurrentPage(page)}
      />
    </div>
  );
};

export default UsersPage;
