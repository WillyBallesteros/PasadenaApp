import React, { useState } from "react";
import { Link } from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import { AppBar, Grid } from "@material-ui/core";
import CardMedia from "@material-ui/core/CardMedia";
import CajaBusqueda from "./CajaBusqueda";
import Logo from "../../images/logoPasadenaShop.jpg";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";
import FavoriteBorderIcon from "@material-ui/icons/FavoriteBorder";
import CardActions from "@material-ui/core/CardActions";
import IconButton from "@material-ui/core/IconButton";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: "2px 4px",
    display: "flex",
    alignItems: "center",
  },
  input: {
    marginLeft: theme.spacing(1),
    flex: 1,
  },
  iconButton: {
    padding: 10,
  },
  media: {
    marginTop: "-12px",
    width: "310px",
    paddingTop: "20.25%", // 16:9
  },
  position: {
    marginLeft: "auto",
  },
}));

const MenuPrincipal = () => {
  const classes = useStyles();

  return (
    <AppBar
      style={{ background: "#ffffff", height: 130, padding: 30 }}
      position="static"
    >
      <Grid container spacing={2}>
        <Grid item item xs={12} md={4}>
          <CardMedia
            className={classes.media}
            image={Logo}
            title="Logo Pasadena Shop"
            component={Link}
            button
            to="/"
          />
        </Grid>
        <Grid item xs={12} md={4}>
          <CajaBusqueda />
        </Grid>
        <Grid item xs={12} md={4}>
          <CardActions style={{ padding: 0 }}>
            <IconButton aria-label="favoritos" className={classes.position}>
              <FavoriteBorderIcon style={{ fontSize: 40, color: "#ccc" }} />
            </IconButton>
            <IconButton aria-label="carrito de compras">
              <ShoppingCartIcon style={{ fontSize: 40, color: "#ccc" }} />
            </IconButton>
          </CardActions>
        </Grid>
      </Grid>
    </AppBar>
  );
};

export default MenuPrincipal;
