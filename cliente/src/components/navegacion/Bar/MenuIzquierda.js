import React from 'react';
import { List, ListItem, ListItemText, Divider } from '@material-ui/core';
import {Link} from 'react-router-dom';

export const MenuIzquierda = ({classes}) => (
    <div className= {classes.list}>
        <List>
            <ListItem component={Link} button to="/auth/perfil">
                <i className="material-icons">account_box</i>
                <ListItemText classes={{primary: classes.listItemText}} primary="Perfil" />
            </ListItem>
        </List>
        <Divider />
        <List>
            <ListItem component={Link} button to="/inicio">
                    <i className="material-icons">home</i>
                    <ListItemText classes={{primary: classes.listItemText}} primary="Inicio" />
            </ListItem>
            <ListItem component={Link} button to="/categorias">
                <i className="material-icons">view_module</i>
                <ListItemText classes={{primary: classes.listItemText}} primary="Categorias" />
            </ListItem>
        </List>
        <Divider />
    </div>
);

