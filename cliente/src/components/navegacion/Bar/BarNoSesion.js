import React, { useState } from "react";
import {
  Toolbar,
  IconButton,
  makeStyles,
  Button,
  Avatar,
  Drawer,
  Typography,
} from "@material-ui/core";
import { useStateValue } from "../../../context/store";
import { MenuIzquierda } from "./MenuIzquierda";
import { withRouter, Link } from "react-router-dom";
import { MenuDerechaNoSesion } from "./MenuDerechaNoSesion";
import AccountCircleIcon from "@material-ui/icons/AccountCircle";
import PersonAddIcon from "@material-ui/icons/PersonAdd";

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
    [theme.breakpoints.up("sm")]: {
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

const BarNoSesion = (props) => {
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
          <MenuDerechaNoSesion classes={classes} />
        </div>
      </Drawer>
      <Toolbar>
        <MenuIzquierda classes={classes} />
        <div className={classes.grow}></div>
        <div className={classes.seccionDesktop}>
          <Button
            color="inherit"
            button
            component={Link}
            button
            to="/auth/login"
          >
            <AccountCircleIcon />&nbsp;
            <Typography variant="body2" color="textSecondary" component="p">
              Ingreso
            </Typography>
          </Button>
          <Button
            color="inherit"
            button
            component={Link}
            button
            to="/auth/registrar"
          >
            <PersonAddIcon />&nbsp;
            <Typography variant="body2" color="textSecondary" component="p">
              Registro
            </Typography>
          </Button>
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

export default withRouter(BarNoSesion);
