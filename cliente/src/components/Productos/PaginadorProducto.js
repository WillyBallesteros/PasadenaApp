import React, { useEffect, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import { paginacionProductoPorGrupo } from "../../actions/ProductoAction";
import { TablePagination, Grid } from "@material-ui/core";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardMedia from "@material-ui/core/CardMedia";
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Avatar from "@material-ui/core/Avatar";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import { red } from "@material-ui/core/colors";
import FavoriteIcon from "@material-ui/icons/Favorite";
import ShareIcon from "@material-ui/icons/Share";
import AddShoppingCartIcon from "@material-ui/icons/AddShoppingCart";
import MoreVertIcon from "@material-ui/icons/MoreVert";
import Leche1 from "../../images/leche1.jpg";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(3, 2),
    width: 1200,
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    marginLeft: "auto",
    marginRight: "auto",
  },
  media: {
    height: 0,
    paddingTop: "56.25%", // 16:9
  },
  expand: {
    transform: "rotate(0deg)",
    marginLeft: "auto",
    transition: theme.transitions.create("transform", {
      duration: theme.transitions.duration.shortest,
    }),
  },
  expandOpen: {
    transform: "rotate(180deg)",
  },
  avatar: {
    backgroundColor: red[500],
  },
}));

const PaginadorProducto = () => {
  const classes = useStyles();
  const [paginadorRequest, setPaginadorRequest] = useState({
    groupId: 1,
    numeroPagina: 0,
    cantidadElementos: 10,
  });

  const [paginadorResponse, setPaginadorResponse] = useState({
    listaRecords: [],
    totalRecords: 0,
    numeroPaginas: 0,
  });

  useEffect(() => {
    const objetoPaginadorRequest = {
      groupId: paginadorRequest.groupId,
      numeroPagina: paginadorRequest.numeroPagina + 1,
      cantidadElementos: paginadorRequest.cantidadElementos,
    };

    const obtenerListaProducto = async () => {
      const response = await paginacionProductoPorGrupo(objetoPaginadorRequest);
      setPaginadorResponse(response.data);
    };

    obtenerListaProducto();
  }, [paginadorRequest]);

  const cambiarPagina = (event, nuevaPagina) => {
    setPaginadorRequest((anterior) => ({
      ...anterior,
      numeroPagina: parseInt(nuevaPagina),
    }));
  };

  const cambiarCantidadRecords = (event) => {
    setPaginadorRequest((anterior) => ({
      ...anterior,
      cantidadElementos: parseInt(event.target.value),
      numeroPagina: 0,
    }));
  };

  return (
    <div className={classes.root}>
      <br />
      <br />
      <Grid
        container
        spacing={2}
        direction="row"
        justify="flex-start"
        alignItems="flex-start"
      >
        {paginadorResponse.listaRecords.map((elem) => (
          <Grid
            item
            xs={12}
            sm={6}
            md={3}
            key={paginadorResponse.listaRecords.indexOf(elem)}
          >
            <Card>
              <CardHeader
                avatar={
                  <Avatar aria-label="recipe" className={classes.avatar}>
                    L
                  </Avatar>
                }
                action={
                  <IconButton aria-label="settings">
                    <MoreVertIcon />
                  </IconButton>
                }
                title={elem.ProductoNombre}
                subheader="Mayo 11, 2020"
              />
              <CardMedia
                className={classes.media}
                image={Leche1}
                title={elem.ProductoNombre}
              />
              <CardContent>
                <Typography variant="body2" color="textSecondary" component="p">
                  {`${elem.Presentacion} X ${elem.Valor}`}
                </Typography>
              </CardContent>
              <CardActions disableSpacing>
                <IconButton aria-label="add to favorites">
                  <FavoriteIcon />
                </IconButton>
                <IconButton aria-label="share">
                  <ShareIcon />
                </IconButton>
                <IconButton aria-label="add to shopping cart">
                  <AddShoppingCartIcon />
                </IconButton>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>
      <TablePagination
        rowsPerPageOptions={[5, 10, 15]}
        count={paginadorResponse.totalRecords}
        rowsPerPage={paginadorRequest.cantidadElementos}
        page={paginadorRequest.numeroPagina}
        onChangePage={cambiarPagina}
        onChangeRowsPerPage={cambiarCantidadRecords}
        labelRowsPerPage="Productos por página"
      ></TablePagination>
    </div>
  );
};

export default PaginadorProducto;
