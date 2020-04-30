import React, { useState } from 'react';
import {Container, Avatar, Typography, TextField, Button} from '@material-ui/core';
import style from '../Tool/Style';
import LockOutlinedIcon from '@material-ui/icons/LockOpenOutlined';

const Login = () => {
  const [usuario, setUsuario] = useState({
      Email : '',
      Password : ''
  });

  const addValuesToMemory = e => {
    const {name, value} = e.target;
    setUsuario(anterior => ({
        ...anterior,
        [name] : value        
    }));
};

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
                <TextField value={usuario.Email} onChange={addValuesToMemory} variant="outlined" label="Ingrese email" name="Email" fullWidth margin="normal"/>
                <TextField value={usuario.Password} onChange={addValuesToMemory} variant="outlined" type="password" label="password" name="Password" fullWidth margin="normal" />
                <Button type="submit" fullWidth variant="contained" color="primary" style={style.submit}>
                    Enviar
                </Button>
            </form>
        </div>
      </Container>
  ); 
}

export default Login;