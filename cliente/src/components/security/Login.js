import React from 'react';
import {Container, Avatar, Typography, TextField, Button} from '@material-ui/core';
import style from '../Tool/Style';
import LockOutlinedIcon from '@material-ui/icons/LockOpenOutlined';

const Login = () => {
  return(
      <Container maxWidth="xs" justify="center">
        <div style={style.paper}>
            <Avatar style={style.avatar}>
                <LockOutlinedIcon style={style.icon}/>
            </Avatar>
            <Typography component="h1" variant="h5">
                Login de Usuario
            </Typography>
            <form style={style.form}>
                <TextField variant="outlined" label="Ingrese email" name="email" fullWidth margin="normal"/>
                <TextField variant="outlined" type="password" label="password" name="password" fullWidth margin="normal" />
                <Button type="submit" fullWidth variant="contained" color="primary" style={style.submit}>
                    Enviar
                </Button>
            </form>
        </div>
      </Container>
  ); 
}

export default Login;