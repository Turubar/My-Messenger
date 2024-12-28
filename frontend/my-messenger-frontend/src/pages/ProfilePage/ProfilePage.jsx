import React from 'react';
import { useOutletContext } from 'react-router-dom';
import { useParams } from "react-router";

import styles from './ProfilePage.module.css';

const PATH_TO_AVATARS = "https://localhost:7180/data/avatars/";

const ProfilePage = () => {
  const profileData = useOutletContext();
  const params = useParams();

  return (
    <div className={"col-12 " + styles.mainContainer}>

      <div className={"col-6 " + styles.flexBlock} style={{marginBottom: '25px'}}>
        <div className={"col-4 "}>

        </div>
        <div className={"col-8 "}>
          {profileData.isMyProfile ? "Это мой профиль" : `Это профиль пользователя с тегом ${profileData.searchTag}`}
        </div>
      </div>

      <div className={"col-6 " + styles.flexBlock}>
        
      </div>

    </div>
  );
};

export default ProfilePage;