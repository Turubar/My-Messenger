import { useEffect, useState } from "react";
import { Navigate, Outlet, useLocation } from "react-router-dom";
import { CircularProgress, Box } from "@mui/material";
import axios from 'axios'

const URL = import.meta.env.VITE_API_URL;

const PrivateRoute = () => {
    const location = useLocation();
    const [showProgress, setShowProgress] = useState(true);
    const [access, setAccess] = useState(false);
    const [data, setData] = useState(null);

    useEffect(() => {
        const fetchAccess = async () => {
            try {
                let response = null;

                if (location.pathname == "/profile")
                    response = await axios.get(URL + `/api/profiles/profile`, { withCredentials: true });
                else if (location.pathname == "/")
                    response = await axios.get(URL + `/api/chats/`, { withCredentials: true });

                setData(response.data);
                setAccess(true);
            }
            catch (error) {
                setAccess(false);
            }
            finally {
                setShowProgress(false);
            }
        };

        fetchAccess();
    }, [])

    if (showProgress) {
        return (
            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    height: '100vh'
                }}>
                <CircularProgress
                    sx={{
                        visibility: showProgress ? 'visible' : 'hidden'
                    }} />
            </Box>
        );
    }

    return access ? <Outlet context={data} /> : <Navigate to="login" />;
};

export default PrivateRoute;