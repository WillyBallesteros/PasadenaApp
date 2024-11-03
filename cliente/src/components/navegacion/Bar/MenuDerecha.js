import React from "react";
import { List, ListItem, ListItemText, Avatar } from "@material-ui/core";
import { Link } from "react-router-dom";
import FotoUsuarioTem from "../../../logo.svg";

export const MenuDerecha = ({ 
  classes, 
  salirSesion, 
  usuario 
}) => (
  <div className={classes.list}>
    <List>
        <ListItem button component={Link}>
            <Avatar src={usuario.imagenPerfil || FotoUsuarioTem}/>
            <ListItemText classes={{primary : classes.listItemText}} primary={usuario ? usuario.nombres : ""}></ListItemText>
        </ListItem>
        <ListItem button onClick={salirSesion}>
            <ListItemText classes={{primary : classes.listItemText}} primary="Salir"></ListItemText>
        </ListItem>
    </List>
  </div>
);
