import { useEffect, useState } from "react";
import { Navigate, Outlet, useLocation } from "react-router-dom";
import { CircularProgress, Box } from "@mui/material";
import { useParams } from "react-router";
import axios from 'axios'

const URL = import.meta.env.VITE_API_URL;

const PrivateRoute = () => {
    const location = useLocation();
    const params = useParams();

    const [showProgress, setShowProgress] = useState(true);
    const [access, setAccess] = useState(false);
    const [data, setData] = useState(null);
    const [navigate, setNavigate] = useState("login");

    useEffect(() => {
        const fetchAccess = async () => {
            try {
                let response = null;
                console.log(URL, location.pathname, params.searchTag);

                if (location.pathname == "/profile") {
                    if (params.searchTag == null)
                        response = await axios.get(URL + `/api/profiles/profile`, { withCredentials: true });
                    else
                        response = await axios.get(URL + `/api/profiles/profile/${params.searchTag}`, { withCredentials: true });

                    setData(response.data);
                    setAccess(true);
                }
                else if (location.pathname == "/") {
                    response = await axios.get(URL + `/api/chats/`, { withCredentials: true });

                    setData(response.data);
                    setAccess(true);
                }
                else {
                    setNavigate("error");
                    setData("Страница не найдена (ошибка 404)");
                    setAccess(false);
                }
            }
            catch (error) {
                setNavigate("error");
                setData(error);
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

    return access ? <Outlet context={data} /> : <Navigate to={navigate} state={data} />;
};

export default PrivateRoute;