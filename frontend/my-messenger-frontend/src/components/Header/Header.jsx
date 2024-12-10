import { Forum } from '@mui/icons-material';
import { AppBar, Box, Link, Toolbar, Typography } from '@mui/material';
import React from 'react';
import styles from './Header.module.css'


function Header() {
    return (
        <AppBar>
            <Box display={'flex'} justifyContent={'center'} alignItems={'center'}>

                <Toolbar>
                    <Link display={'flex'} flexDirection={'row'} href="/profile" underline="none">
                        <Forum sx={{ color: 'white' }} />

                        <Typography paddingLeft={'10px'} className={styles.page_text}>
                            MY MESSENGER
                        </Typography>
                    </Link>
                </Toolbar>

                <Toolbar>
                    <Link href="/login" underline="none">
                        <Typography className={styles.page_text}>
                            LOGIN
                        </Typography>
                    </Link>

                    <Link href="/register" underline="none" paddingLeft={'10px'}>
                        <Typography className={styles.page_text}>
                            REGISTER
                        </Typography>
                    </Link>
                </Toolbar>
            </Box>
        </AppBar>
    );
}

export default Header;