import './App.css'
import { Route, Routes } from 'react-router-dom';
import { HomePage, LoginPage, ProfilePage, RegisterPage, ErrorPage } from './pages'
import PrivateRoute from './utils/router/privateRoute';

function App() {
  return (
    <>
      <Routes>
        <Route path="register" element={<RegisterPage />} />
        <Route path="login" element={<LoginPage />} />

        <Route element={<PrivateRoute />}>
          <Route path="/" element={<HomePage />} />
          <Route path="profile/:searchTag?" element={<ProfilePage />} />
        </Route>

        <Route path="*" element={<ErrorPage />} />
      </Routes>
    </>
  );
}

export default App;
