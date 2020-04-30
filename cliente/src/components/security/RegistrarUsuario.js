import React, {useState} from 'react';
import {Container, Typography, TextField, Grid, Button} from '@material-ui/core';
import style from '../Tool/Style';
import {registrarUsuario} from '../../actions/UsuarioAction';

const RegistrarUsuario = () => {
    const [usuario, setUsuario] = useState({
        Nombres: '',
        Apellidos: '',
        Email: '',
        Password: '',
        ConfirmPassword: ''
    });

    const addValuesToMemory = e => {
      const {name, value} = e.target;
      setUsuario(anterior => ({
          ...anterior,
          [name]: value
      }));
    }

    const registrarUsuarioBtn = e => {
        e.preventDefault();
        registrarUsuario(usuario).then(response => {
            console.log("registro de usuario", response);
            console.log(response);
            window.localStorage.setItem("token_seguridad", response.data.result != null && response.data.result.token);
        });
    }

    return(
      <Container component="main" maxWidth="md" justify="center">
        <div style={style.paper}>
            <Typography component="h1" variant="h5">
                Registro de Usuario
            </Typography>
            <form style={style.form}>
                <Grid container spacing={2}>
                    <Grid item xs={12} md={6}>
                        <TextField name="Nombres" value={usuario.Nombres} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese su nombre"/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="Apellidos" value={usuario.Apellidos} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese su apellido"/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="Email" value={usuario.Email} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese su email"/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="Password" value={usuario.Password} onChange={addValuesToMemory}  type="password" variant="outlined" fullWidth label="Ingrese su password"/>           
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="ConfirmPassword" value={usuario.ConfirmPassword} onChange={addValuesToMemory} type="password" variant="outlined" fullWidth label="Confirme su password"/>
                    </Grid>
                </Grid>
                <Grid container justify="center">
                    <Grid item xs={12} md={6}>
                        <Button type="submit" onClick={ registrarUsuarioBtn } fullWidth variant="contained" color="primary" size="large" style={style.submit}>
                            Enviar
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </div>
      </Container>
  ); 
}

export default RegistrarUsuario;