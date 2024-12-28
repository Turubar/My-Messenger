import React from 'react';
import { useLocation } from 'react-router-dom';

const ErrorPage = () => {
  const location = useLocation();

  console.log(location);
  return (
    <div>
      {"Error page:" +  location.state}
    </div>
  );
};

export default ErrorPage;