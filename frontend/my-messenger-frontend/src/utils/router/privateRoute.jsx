import { useEffect } from "react";
import { Navigate, Outlet, useLocation } from "react-router-dom";

const PrivateRoute = () => {
    const location = useLocation();

    useEffect(() => {
        console.log(location.pathname);
    })

    return (
       <div>
        123
       </div>
    );
};

export default PrivateRoute;