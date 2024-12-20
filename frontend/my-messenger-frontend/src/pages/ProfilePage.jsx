import React from 'react';
import { useOutletContext } from 'react-router-dom';

const ProfilePage = () => {
  const profileData = useOutletContext();

  return (
    <div>
      <h1>{profileData.displayName}</h1>
    </div>
  );
};

export default ProfilePage;