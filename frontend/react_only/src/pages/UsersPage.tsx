import React from "react";
import useRandomUser from "../hooks/useFetchUsers.ts";
import RandomUserCard from "../components/RandomUserCard";

const UsersPage: React.FC = () => {
  const { data, isLoading, error } = useRandomUser();

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;
  
  return (
    <div>
      <h1>Random User</h1>
      {data?.results.map((user, index) => (
        <RandomUserCard key={index} user={user} />
      ))}
    </div>
  );
};

export default UsersPage;
