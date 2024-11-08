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
import ExitToAppIcon from '@material-ui/icons/ExitToApp';


const useStyles = makeStyles((theme) => ({
  root: {
    height: 33,
  },
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
    width: 30,
    height: 30,
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

    dispatch({
      type : "SALIR_SESION",
      nuevoUsuario : null,
      autenticado : false
    })

    props.history.push("/auth/login");
  };

  return (
    <React.Fragment> 
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
        <MenuIzquierda classes={classes}/>
        <div className={classes.grow}></div>
        <div className={classes.seccionDesktop}>
          <Button color="inherit" onClick={salirSessionApp}>
            <ExitToAppIcon />
          </Button>
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
