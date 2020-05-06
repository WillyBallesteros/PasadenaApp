import React, { useState } from "react";
import {
  Container,
  Avatar,
  Typography,
  TextField,
  Button,
} from "@material-ui/core";
import style from "../Tool/Style";
import LockOutlinedIcon from "@material-ui/icons/LockOpenOutlined";
import { loginUsuario } from "../../actions/UsuarioAction";
import { withRouter } from "react-router-dom";
import { useStateValue } from "../../context/store";

const Login = (props) => {
  const [{ sesionUsuario }, dispatch] = useStateValue();
  const [usuario, setUsuario] = useState({
    Email: "",
    Password: "",
  });

  const addValuesToMemory = (e) => {
    const { name, value } = e.target;
    setUsuario((anterior) => ({
      ...anterior,
      [name]: value,
    }));
  };

  const loginUsuarioBtn = (e) => {
    e.preventDefault();
    loginUsuario(usuario, dispatch).then((response) => {
      if (response.status === 200) {
        window.localStorage.setItem(
          "token_seguridad",
          response.data.result != null && response.data.result.token
        );
        props.history.push("/");
      } else {
        dispatch({
          type: "OPEN_SNACKBAR",
          openMensaje: {
            open: true,
            mensaje: "Las credenciales del usuario son incorrectas",
          },
        });
      }
    });
  };

  return (
    <Container maxWidth="xs" justify="center">
      <div style={style.paper}>
        <Avatar style={style.avatar}>
          <LockOutlinedIcon style={style.icon} />
        </Avatar>
        <Typography component="h1" variant="h5">
          Login de Usuario
        </Typography>
        <form style={style.form}>
          <TextField
            value={usuario.Email}
            onChange={addValuesToMemory}
            variant="outlined"
            label="Ingrese email"
            name="Email"
            fullWidth
            margin="normal"
          />
          <TextField
            value={usuario.Password}
            onChange={addValuesToMemory}
            variant="outlined"
            type="password"
            label="password"
            name="Password"
            fullWidth
            margin="normal"
          />
          <Button
            type="submit"
            onClick={loginUsuarioBtn}
            fullWidth
            variant="contained"
            color="primary"
            style={style.submit}
          >
            Enviar
          </Button>
        </form>
      </div>
    </Container>
  );
};

export default withRouter(Login);
