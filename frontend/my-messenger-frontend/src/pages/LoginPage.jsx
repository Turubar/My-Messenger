import { Alert, Box, Button, Checkbox, CircularProgress, FormControlLabel, Link, TextField, Typography } from '@mui/material';
import React, { useState } from 'react';
import { loginUserAPI } from '../api/users';


const LoginPage = () => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);
    const [showProgress, setShowProgress] = useState(false);

    const [alert, setAlert] = useState({
        severity: "success",
        message: "",
        visability: false
      });


      
    const loginUser = async () => {
      // валидация


      setShowProgress(prev => prev = true);

      const alert = await loginUserAPI(login, password);
      showAlert(alert.severity, alert.message);

      setShowProgress(prev => prev = false);
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
        В Х О Д
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
            marginBottom: '15px'
          }}
        />

        <div style={{ display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
          <FormControlLabel
            control={<Checkbox
              onChange={(e) => setShowPassword(e.target.checked)}
              sx={{ 
                width: '18px',
                height: '18px', 
                marginLeft: '5px' 
              }}
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
          onClick={loginUser}
          size='large'
          sx={{
            padding: '12px',
            margin: '0',
            marginBottom: '15px'
          }}
        >
          Войти
        </Button>

        <Link href="/register" underline="hover" textAlign={"center"}>
          Зарегистрировать аккаунт
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

export default LoginPage;