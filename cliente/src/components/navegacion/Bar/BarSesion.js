import React, { useState } from "react";
import {
  Toolbar,
  IconButton,
  Typography,
  makeStyles,
  Button,
  Avatar,
  Drawer
} from "@material-ui/core";
import FotoUsuarioTemp from "../../../logo.svg";
import { useStateValue } from "../../../context/store";
import { MenuIzquierda } from "./MenuIzquierda";
import { withRouter } from "react-router-dom";
import { MenuDerecha } from "./MenuDerecha";

const useStyles = makeStyles((theme) => ({
  seccionDesktop: {
    display: "none",
    [theme.breakpoints.up("md")]: {
      display: "flex",
    },
  },
  seccionMobile: {
    display: "flex",
    [theme.breakpoints.up('sm')]: {
      display: "none",
    },
  },
  grow: {
    flexGrow: 1,
  },
  avatarSize: {
    width: 40,
    height: 40,
  },
  list: {
    width: 250,
  },
  listItemText: {
    fontSize: "14px",
    fontWeight: 600,
    paddingLeft: "15px",
    color: "#212121",
  },
}));

const BarSesion = (props) => {
  const classes = useStyles();
  const [{ sesionUsuario }, dispatch] = useStateValue();
  const [abrirMenuIzquierda, setAbrirMenuIzquierda] = useState(false);
  const [abrirMenuDerecha, setAbrirMenuDerecha] = useState(false);

  const cerrarMenuIzquierda = () => {
    setAbrirMenuIzquierda(false);
  };

  const abrirMenuIzquierdaAction = () => {
    setAbrirMenuIzquierda(true);
  };

  const cerrarMenuDerecha = () => {
    setAbrirMenuDerecha(false);
  };

  const abrirMenuDerechaAction = () => {
    setAbrirMenuDerecha(true);
  };

  const salirSessionApp = () => {
    window.localStorage.removeItem("token_seguridad");
    props.history.push("/auth/login");
  };

  return (
    <React.Fragment>
      <Drawer
        open={abrirMenuIzquierda}
        onClose={cerrarMenuIzquierda}
        anchor="left"
      >
        <div
          className={classes.list}
          onKeyDown={cerrarMenuIzquierda}
          onClick={cerrarMenuIzquierda}
        >
          <MenuIzquierda classes={classes}/>
        </div>
      </Drawer>
      <Drawer
        open={abrirMenuDerecha}
        onClose={cerrarMenuDerecha}
        anchor="right"
      >
        <div
          className={classes.list}
          onKeyDown={cerrarMenuDerecha}
          onClick={cerrarMenuDerecha}
        >
          <MenuDerecha
            classes={classes}
            salirSession={salirSessionApp}
            usuario={sesionUsuario ? sesionUsuario.usuario : null}
          />
        </div>
      </Drawer>
      <Toolbar>
        <IconButton color="inherit" onClick={abrirMenuIzquierdaAction}>
          <i className="material-icons">menu</i>
        </IconButton>
        <Typography variant="h6">Pasadena App</Typography>
        <div className={classes.grow}></div>
        <div className={classes.seccionDesktop}>
          <Button color="inherit" onClick={salirSessionApp}>Salir</Button>
          <Button color="inherit">
            {sesionUsuario ? sesionUsuario.usuario.nombres : ""}
          </Button>
          <Avatar src={sesionUsuario.usuario.imagenPerfil || FotoUsuarioTemp}></Avatar>
        </div>
        <div className={classes.seccionMobile}>
          <IconButton color="inherit" onClick={abrirMenuDerechaAction}>
            <i className="material-icons">more_vert</i>
          </IconButton>
        </div>
      </Toolbar>
    </React.Fragment>
  );
};

export default withRouter(BarSesion);
