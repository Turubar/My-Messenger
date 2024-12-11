import { Box, Button, Checkbox, FormControlLabel, Link, TextField, Typography } from '@mui/material';
import React, { useState } from 'react';

const RegisterPage = () => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [confirmedPassword, setConfirmedPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);

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
        // component={'form'}
        display={'flex'}
        flexDirection={'column'}
        borderRadius={'5px'}
        padding={'25px'}
        boxShadow={'rgba(6, 24, 44, 0.4) 0px 0px 0px 2px, rgba(6, 24, 44, 0.65) 0px 4px 6px -1px, rgba(255, 255, 255, 0.08) 0px 1px 0px inset;'}
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

    </Box>
  );
};

export default RegisterPage;