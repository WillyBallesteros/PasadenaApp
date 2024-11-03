import React from "react";
import { Toolbar, IconButton } from "@material-ui/core";
import { Link } from "react-router-dom";
import FacebookIcon from "@material-ui/icons/Facebook";
import InstagramIcon from '@material-ui/icons/Instagram';
import HomeIcon from '@material-ui/icons/Home';

export const MenuIzquierda = ({ classes }) => (
  <Toolbar>
    <IconButton aria-label="home" component={Link} button to="/" >
      <HomeIcon />
    </IconButton>
    <IconButton aria-label="facebook">
      <FacebookIcon />
    </IconButton>
    <IconButton aria-label="instagram">
      <InstagramIcon />
    </IconButton>
  </Toolbar>
);