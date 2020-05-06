import React from 'react';
import {AppBar} from '@material-ui/core';
import BarSesion from './Bar/BarSesion';
import { useStateValue } from "../../context/store";

const AppNavBar = () => {
    const [{ sesionUsuario }, dispatch] = useStateValue();
    if(sesionUsuario && sesionUsuario.autenticado) {
        return (
            <AppBar position="static">
                <BarSesion />
            </AppBar>
        );
    }
    return (
        <AppBar position="static">
        </AppBar>
    );
};

export default AppNavBar;