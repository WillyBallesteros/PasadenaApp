import React from 'react';
import style from '../Tool/Style';
import { Container, Typography, TextField, Grid, Button } from '@material-ui/core';

const PerfilUsuario = () => {
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
                        <TextField name="nombre" variant="outlined" fullWidth label="Ingrese nombre" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="apellidos" variant="outlined" fullWidth label="Ingrese apellido" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="email" variant="outlined" fullWidth label="Ingrese email" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="telefono" variant="outlined" fullWidth label="Ingrese teléfono" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="tipodocumento" variant="outlined" fullWidth label="Tipo documento" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="documento" variant="outlined" fullWidth label="Ingrese numero documento" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="ciudad" variant="outlined" fullWidth label="Ingrese ciudad" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="puntoventa" variant="outlined" fullWidth label="Ingrese punto de venta" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="password" type="password" variant="outlined" fullWidth label="Ingrese password" />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name="confirmepassword" type="password" variant="outlined" fullWidth label="Confirme password" />
                    </Grid>
                </Grid>
                <Grid container justify="center">
                    <Grid item xs={12} md={6}>
                        <Button type="submit" variant="contained" fullWidth color="primary" size="large" style={style.submit}>
                            Guardar Datos
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </Container>
    );
};

export default PerfilUsuario;