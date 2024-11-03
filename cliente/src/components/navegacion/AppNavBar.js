import React from 'react';
import {AppBar} from '@material-ui/core';
import BarSesion from './Bar/BarSesion';
import BarNoSesion from './Bar/BarNoSesion';
import { useStateValue } from "../../context/store";

const AppNavBar = () => {
    const [{ sesionUsuario }, dispatch] = useStateValue();
    
    return sesionUsuario
      ? (sesionUsuario.autenticado == true ? 
      <AppBar style={{ background: '#f8f8f8', height: 33 }} position="static">
        <BarSesion />
      </AppBar> : <AppBar style={{ background: '#f8f8f8', height: 33 }} position="static">
        <BarNoSesion />
      </AppBar>)
      : <AppBar style={{ background: '#f8f8f8', height: 33 }} position="static">
      <BarNoSesion />
    </AppBar>
};

export default AppNavBar;