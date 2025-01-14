import React from 'react';
import { RandomUser } from '../types/RandomUserTypes';

interface RandomUserCardProps {
  user: RandomUser;
}

/**
 * A card component to display random user information.
 * @param {RandomUserCardProps} props - The props containing the user data.
 */
const RandomUserCard: React.FC<RandomUserCardProps> = ({ user }) => {
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

export default RandomUserCard;
