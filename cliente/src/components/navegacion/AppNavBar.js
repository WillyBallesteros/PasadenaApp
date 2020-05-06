import React from 'react';
import {AppBar} from '@material-ui/core';
import BarSesion from './Bar/BarSesion';
import { useStateValue } from "../../context/store";

const AppNavBar = () => {
    const [{ sesionUsuario }, dispatch] = useStateValue();
    
    return sesionUsuario
      ? (sesionUsuario.autenticado == true ? <AppBar position="static"><BarSesion /></AppBar> : null)
      : null
};

export default AppNavBar;