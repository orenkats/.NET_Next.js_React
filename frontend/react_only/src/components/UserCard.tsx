import React from 'react';
import { User } from '../types/User';

interface UserCardProps {
  user: User;
}

/**
 * A card component to display random user information.
 * @param {UserCardProps} props - The props containing the user data.
 */
const UserCard: React.FC<UserCardProps> = ({ user }) => {
  return (
    <div style={{ border: '1px solid #ddd', padding: '16px', borderRadius: '8px' }}>
      <img
        
      />
      <h2>
        {user.name.title} {user.name.first} {user.name.last}
      </h2>
      <p>Email: {user.email}</p>
      <p>Gender: {user.gender}</p>
    </div>
  );
};

export default UserCard;
