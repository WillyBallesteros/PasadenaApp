import React, {useState, useEffect} from 'react';
import style from '../Tool/Style';
import { Container, Typography, TextField, Grid, Button } from '@material-ui/core';
import { obtenerUsuarioActual, actualizarUsuario } from '../../actions/UsuarioAction';


const PerfilUsuario = () => {

    const [usuario, setUsuario] = useState({
        nombres: '',
        apellidos: '',
        email: '',
        telefono: '',
        tipoDocumentoId: '',
        numeroCedula: '',
        ciudadId: '',
        puntoVentaId: '',
        password: '',
        confirmPassword: ''
    });

    const addValuesToMemory = e => {
        const {name, value} = e.target;
        setUsuario(anterior => ({
            ...anterior,
            [name] : value        
        }));
    };

    useEffect(() => {
        obtenerUsuarioActual().then(response => {
            console.log('data del usuario actual', response);
            setUsuario(response.data.result);
        })
    }, []);

    const guardarUsuario = e => {
        e.preventDefault();
        actualizarUsuario(usuario).then(response => {
            window.localStorage.setItem("token_seguridad", response.data.result != null && response.data.result.token);
        })
    }


    return (
        <Container component="main" maxWidth="md" justify="center">
            <div style={style.paper}>
                <Typography component="h1" variant="h5">
                    Perfil de Usuario
                </Typography>
            </div>
            <form style={style.form}>
                <Grid container spacing={2}>
                    <Grid item xs={12} md={6}>
                        <TextField name="nombres" value={usuario.nombres} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese nombre" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="apellidos" value={usuario.apellidos} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese apellido" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="email" value={usuario.email} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese email" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="telefono" value={usuario.telefono}  onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese teléfono" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="tipoDocumentoId" value={usuario.tipoDocumentoId} onChange={addValuesToMemory} variant="outlined" fullWidth label="Tipo documento" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="numeroCedula" value={usuario.numeroCedula} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese numero documento" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="ciudadId" value={usuario.ciudadId} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese ciudad" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="puntoVentaId" value={usuario.puntoVentaId} onChange={addValuesToMemory} variant="outlined" fullWidth label="Ingrese punto de venta" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="password" value={usuario.password} onChange={addValuesToMemory} type="password" variant="outlined" fullWidth label="Ingrese password" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="confirmPassword" value={usuario.confirmPassword} onChange={addValuesToMemory} type="password" variant="outlined" fullWidth label="Confirme password" />
                    </Grid>
                </Grid>
                <Grid container justify="center">
                    <Grid item xs={12} md={6}>
                        <Button type="submit" onClick={guardarUsuario} variant="contained" fullWidth color="primary" size="large" style={style.submit}>
                            Guardar Datos
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </Container>
    );
};

export default PerfilUsuario;