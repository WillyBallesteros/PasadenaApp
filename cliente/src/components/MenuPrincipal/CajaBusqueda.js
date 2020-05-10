import React, {useState} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import InputBase from '@material-ui/core/InputBase';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import { withRouter } from "react-router-dom";
import { useStateValue } from "../../context/store";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: '2px 4px',
    display: 'flex',
    alignItems: 'center',
    width: 400,
    margin: "auto",
    marginTop: '10px'
  },
  input: {
    marginLeft: theme.spacing(1),
    flex: 1,
  },
  iconButton: {
    padding: 10,
  }
}));



const CajaBusqueda = (props) => {
  const classes = useStyles();
  const [{ searchProduct }, dispatch] = useStateValue();
  const [palabra, setPalabra] = useState('');

  const addValuesToMemory = (e) => {
    setPalabra(e.target.value)
  };

  const searchBtn = (e) => {
    e.preventDefault();
    dispatch({
      type : "ACTUALIZAR_PALABRA",
      palabra : palabra,
    })
    props.history.push("/producto/busqueda/" + palabra);
  };

  return (
    <Paper component="form" className={classes.root}>
      <InputBase
        value={palabra}
        className={classes.input}
        placeholder="Buscar"
        inputProps={{ 'aria-label': 'buscar producto' }}
        onChange={addValuesToMemory}
      />
      <IconButton type="submit" className={classes.iconButton} aria-label="search" onClick={searchBtn}>
        <SearchIcon />
      </IconButton>
    </Paper>
  );
}

export default withRouter(CajaBusqueda);