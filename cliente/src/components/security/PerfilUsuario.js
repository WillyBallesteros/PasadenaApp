import React, { useState, useEffect } from "react";
import style from "../Tool/Style";
import {
  Container,
  Typography,
  TextField,
  Grid,
  Button,
  Avatar,
} from "@material-ui/core";
import { actualizarUsuario } from "../../actions/UsuarioAction";
import { useStateValue } from "../../context/store";
import reactfoto from "../../logo.svg";
import { v4 as uuidv4 } from "uuid";
import ImageUploader from "react-images-upload";
import { obtenerDataImagen } from "../../actions/ImagenAction";

const PerfilUsuario = () => {
  const [{ sesionUsuario }, dispatch] = useStateValue();

  const [usuario, setUsuario] = useState({
    nombres: "",
    apellidos: "",
    email: "",
    telefono: "",
    tipoDocumentoId: "",
    numeroCedula: "",
    ciudadId: "",
    puntoVentaId: "",
    password: "",
    confirmPassword: "",
    imagenPerfil: null,
    fotoUrl: "",
  });

  const addValuesToMemory = (e) => {
    const { name, value } = e.target;
    setUsuario((anterior) => ({
      ...anterior,
      [name]: value,
    }));
  };

  useEffect(() => {
    if (sesionUsuario) {
      setUsuario(sesionUsuario.usuario);
      setUsuario((anterior) => ({
        ...anterior,
        fotoUrl: sesionUsuario.usuario.imagenPerfil,
        imagenPerfil : null
      }));
    }
  }, []);

  const guardarUsuario = (e) => {
    e.preventDefault();
    actualizarUsuario(usuario, dispatch).then((response) => {

      if (response.status === 200) {
        dispatch({
          type: "OPEN_SNACKBAR",
          openMensaje: {
            open: true,
            mensaje: "Se guardaron exitosamente los cambios en Perfil usuario",
          },
        });
        window.localStorage.setItem(
          "token_seguridad",
          response.data.result != null && response.data.result.token
        );
      } else {
        dispatch({
          type: "OPEN_SNACKBAR",
          openMensaje: {
            open: true,
            mensaje:
              "Errores al intentar guardar en  : " +
              Object.keys(response.data.errors),
          },
        });
      }
    });
  };

  const subirFoto = (imagenes) => {
    const foto = imagenes[0];
    const fotoUrl = URL.createObjectURL(foto);

    obtenerDataImagen(foto).then((respuesta) => {
      setUsuario((anterior) => ({
        ...anterior,
        imagenPerfil: respuesta, //respuesta es un json que proviene del action obtener imagen { data : ..., nombre: ..., extension: ...}
        fotoUrl: fotoUrl, //formato URL
      }));
    });
  };

  const fotoKey = uuidv4();

  return (
    <Container component="main" maxWidth="md" justify="center">
      <div style={style.paper}>
        <Avatar style={style.paper} src={usuario.fotoUrl || reactfoto} />
        <Typography component="h1" variant="h5">
          Perfil de Usuario
        </Typography>

        <form style={style.form}>
          <Grid container spacing={2}>
            <Grid item xs={12} md={6}>
              <TextField
                name="nombres"
                value={usuario.nombres}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Ingrese nombre"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="apellidos"
                value={usuario.apellidos}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Ingrese apellido"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="email"
                value={usuario.email}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Ingrese email"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="telefono"
                value={usuario.telefono}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Ingrese teléfono"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="tipoDocumentoId"
                value={usuario.tipoDocumentoId}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Tipo documento"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="numeroCedula"
                value={usuario.numeroCedula}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Ingrese numero documento"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="ciudadId"
                value={usuario.ciudadId}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Ingrese ciudad"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="puntoVentaId"
                value={usuario.puntoVentaId}
                onChange={addValuesToMemory}
                variant="outlined"
                fullWidth
                label="Ingrese punto de venta"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="password"
                value={usuario.password}
                onChange={addValuesToMemory}
                type="password"
                variant="outlined"
                fullWidth
                label="Ingrese password"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="confirmPassword"
                value={usuario.confirmPassword}
                onChange={addValuesToMemory}
                type="password"
                variant="outlined"
                fullWidth
                label="Confirme password"
              />
            </Grid>
            <Grid item xs={12} md={12}>
              <ImageUploader
                withIcon={false}
                key={fotoKey}
                singleImage={true}
                buttonText="Seleccione una imagen de perfil"
                onChange={subirFoto}
                imgExtension={[".jpg", ".gif", ".png", ".jpeg"]}
                maxFileSize={5242880}
              />
            </Grid>
          </Grid>
          <Grid container justify="center">
            <Grid item xs={12} md={6}>
              <Button
                type="submit"
                onClick={guardarUsuario}
                variant="contained"
                fullWidth
                color="primary"
                size="large"
                style={style.submit}
              >
                Guardar Datos
              </Button>
            </Grid>
          </Grid>
        </form>
      </div>
    </Container>
  );
};

export default PerfilUsuario;
