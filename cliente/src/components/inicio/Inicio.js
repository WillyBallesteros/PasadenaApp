import React, { useState } from 'react';
import {Container, Avatar, Typography, TextField, Button} from '@material-ui/core';
import style from '../Tool/Style';
import LockOutlinedIcon from '@material-ui/icons/LockOpenOutlined';
import { loginUsuario } from '../../actions/UsuarioAction';

const Inicio = () => {
  
  return(
      <Container maxWidth="xs" justify="center">
        <h1>Inicio</h1>      
      </Container>
  ); 
}

export default Inicio;