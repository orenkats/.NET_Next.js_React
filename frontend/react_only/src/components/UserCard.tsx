import React from "react";
import { User } from "../types/User";
import styles from "./userCard.module.scss";

interface UserCardProps {
  user: User;
}

const UserCard: React.FC<UserCardProps> = ({ user }) => {
  // Helper function to render user details
  const renderDetails = () => (
    <>
      <h2 className={styles.userName}>
        {user.name.title} {user.name.first} {user.name.last}
      </h2>
      <p className={styles.userEmail}>Email: {user.email}</p>
      <p className={styles.userGender}>Gender: {user.gender}</p>
    </>
  );

  return (
    <div className={styles.userCard}>
      <img
        src={user.picture.thumbnail}
        alt={`${user.name.first} ${user.name.last}`}
        className={styles.userImage}
      />
      {renderDetails()}
    </div>
  );
};

export default UserCard;
