import React from "react";
import { Toolbar, IconButton } from "@material-ui/core";
import { Link } from "react-router-dom";
import FacebookIcon from "@material-ui/icons/Facebook";
import InstagramIcon from '@material-ui/icons/Instagram';

export const MenuIzquierda = ({ classes }) => (
  <Toolbar>
    <IconButton aria-label="facebook">
      <FacebookIcon />
    </IconButton>
    <IconButton aria-label="instagram">
      <InstagramIcon />
    </IconButton>
  </Toolbar>
);