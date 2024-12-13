import { Alert, Box, Button, Checkbox, CircularProgress, FormControlLabel, Link, TextField, Typography } from '@mui/material';
import React, { useState } from 'react';
import { registerUserAPI } from '../api/users';
import { Navigate, useNavigate } from 'react-router-dom';

const MIN_LOGIN_LENGTH = 4;
const MAX_LOGIN_LENGTH = 20;

const MIN_PASSWORD_LENGTH = 8;
const MAX_PASSWORD_LENGTH = 30;

const RegisterPage = () => {
  const navigate = useNavigate();

  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [confirmedPassword, setConfirmedPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const [showProgress, setShowProgress] = useState(false);
  
  const [alert, setAlert] = useState({
    severity: "success",
    message: "",
    visability: false
  });


  const registerUser = async () => {
    if (login.length < MIN_LOGIN_LENGTH || login.length > MAX_LOGIN_LENGTH) {
      showAlert("warning", `Длина логина должна быть [${MIN_LOGIN_LENGTH} - ${MAX_LOGIN_LENGTH}] символов`);
      return;
    }

    if (password.length < MIN_PASSWORD_LENGTH || password.length > MAX_PASSWORD_LENGTH) {
      showAlert("warning", `Длина пароля должна быть [${MIN_PASSWORD_LENGTH} - ${MAX_PASSWORD_LENGTH}] символов`);
      return;
    }

    if (confirmedPassword.length < MIN_PASSWORD_LENGTH || confirmedPassword.length > MAX_PASSWORD_LENGTH) {
      showAlert("warning", `Длина пароля должна быть [${MIN_PASSWORD_LENGTH} - ${MAX_PASSWORD_LENGTH}] символов`);
      return;
    }

    if (password != confirmedPassword) {
      showAlert("warning", "Пароли не совпадают");
      return;
    }

    setShowProgress(prev => prev = true);

    const alert = await registerUserAPI(login, password);
    showAlert(alert.severity, alert.message);

    setShowProgress(prev => prev = false);

    if (alert.success) {
      setInterval(() => {
        navigate("/login")
      }, 3000)
    }
  }

  const showAlert = (severity, message) => {
    setAlert({
      severity: severity,
      message: message,
      visability: true
    })

    setTimeout(() => {
      setAlert(prev => {
        return {
          ...prev,
          visability: false
        }
      })
    }, 4000)
  }

  return (
    <Box
      display={'flex'}
      flexDirection={'column'}
      alignItems={'center'}
      justifyContent={'center'}
      sx={{
        height: '100vh'
      }}
    >
      <Typography
        fontSize={'40px'}
        fontFamily={'Roboto-Bold'}
        marginBottom={'15px'}
      >
        Р Е Г И С Т Р А Ц И Я
      </Typography>

      <Box
        width={'425px'}
        component={'form'}
        onSubmit={(e) => e.preventDefault()}
        display={'flex'}
        flexDirection={'column'}
        borderRadius={'5px'}
        padding={'25px'}
        boxShadow={'rgba(6, 24, 44, 0.4) 0px 0px 0px 2px, rgba(6, 24, 44, 0.65) 0px 4px 6px -1px, rgba(255, 255, 255, 0.08) 0px 1px 0px inset;'}
        marginBottom={'25px'}
      >
        <TextField
          label="Введите логин"
          name="login"
          onChange={(e) => setLogin(e.target.value)}
          variant="outlined"
          autoComplete="off"
          required
          sx={{
            textAlign: 'center',
            marginTop: '0',
            marginBottom: '25px'
          }}
        />

        <TextField
          label="Введите пароль"
          name="password"
          onChange={(e) => setPassword(e.target.value)}
          variant="outlined"
          type={showPassword ? "text" : "password"}
          autoComplete="off"
          required
          sx={{
            textAlign: 'center',
            marginTop: '0',
            marginBottom: '25px'
          }}
        />

        <TextField
          label="Повторите пароль"
          name="confirmedPassword"
          onChange={(e) => setConfirmedPassword(e.target.value)}
          variant="outlined"
          type={showPassword ? "text" : "password"}
          autoComplete="off"
          required
          sx={{
            textAlign: 'center',
            marginTop: '0',
            marginBottom: '15px'
          }}
        />

        <div style={{ display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
          <FormControlLabel
            control={<Checkbox
              onChange={(e) => setShowPassword(e.target.checked)}
              sx={{ width: '18px', height: '18px', marginLeft: '5px' }}
            />}
            label="Показать пароль"
            labelPlacement="start"
            sx={{
              margin: '0',
              marginBottom: '25px',
            }}
          />
        </div>

        <Button
          variant="contained"
          onClick={registerUser}
          size='large'
          sx={{
            padding: '12px',
            margin: '0',
            marginBottom: '15px'
          }}
        >
          Продолжить
        </Button>

        <Link href="/login" underline="hover" textAlign={"center"}>
          Вернуться обратно
        </Link>
      </Box>

      <Alert variant="outlined" severity={alert.severity}
        sx={{
          fontSize: '16px',
          visibility: alert.visability ? 'visible' : 'hidden',
          marginBottom: '25px'
        }}
      >
        {alert.message}
      </Alert>
      <CircularProgress sx={{
        visibility: showProgress ? 'visible' : 'hidden'
      }}/>
    </Box>
  );
};

export default RegisterPage;