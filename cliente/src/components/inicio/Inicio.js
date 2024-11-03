import React from "react";
import { Grid, Typography } from "@material-ui/core";
import MenuPrincipal from "../MenuPrincipal/MenuPrincipal";
import BannerPromociones from "./BannerPromociones";
import ProductosDestacados from "./ProductosDestacados";

const Inicio = () => {
  return (
    <Grid xs={12} container>
      <br/>
      <MenuPrincipal/>
      <BannerPromociones/>
      <Grid xs={12} style={{backgroundColor:"#f8f8f8", color: "#6E6E6E", textAlign: "center", padding:"10px"}}>
        <Typography>
          PRODUCTOS DESTACADOS
        </Typography>
      </Grid>
      <ProductosDestacados />
    </Grid>

  );
};

export default Inicio;
