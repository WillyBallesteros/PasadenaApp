import React from "react";
import { List, ListItem, ListItemText, Avatar } from "@material-ui/core";
import { Link } from "react-router-dom";
import AccountCircleIcon from "@material-ui/icons/AccountCircle";
import PersonAddIcon from "@material-ui/icons/PersonAdd";

export const MenuDerechaNoSesion = ({ classes, salirSesion, usuario }) => (
  <div className={classes.list}>
    <List>
      <ListItem button component={Link} button to="/auth/login">
        <AccountCircleIcon />
        <ListItemText
          classes={{ primary: classes.listItemText }}
          primary="Ingreso"
        ></ListItemText>
      </ListItem>
      <ListItem button component={Link} button to="/auth/registrar">
        <PersonAddIcon />
        <ListItemText
          classes={{ primary: classes.listItemText }}
          primary="Registro"
        ></ListItemText>
      </ListItem>
    </List>
  </div>
);
