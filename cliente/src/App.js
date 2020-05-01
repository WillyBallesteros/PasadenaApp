import React , {useState} from 'react';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import {ThemeProvider as MuithemeProvider} from "@material-ui/core/styles";
import theme from './theme/theme';
import PerfilUsuario from './components/security/PerfilUsuario';
import RegistrarUsuario from './components/security/RegistrarUsuario';
import Login from './components/security/Login';
import { Grid } from '@material-ui/core';
import AppNavBar from './components/navegacion/AppNavBar';

function App() {
  
  return (
    <Router>
    <MuithemeProvider theme={theme}>
      <AppNavBar/>
      <Grid container>
        <Switch>
          <Route exact path="/auth/login" component={Login}/>
          <Route exact path="/auth/registrar" component={RegistrarUsuario}/>
          <Route exact path="/auth/perfil" component={PerfilUsuario}/>
          <Route exact path="/" component={PerfilUsuario}/>
        </Switch>
      </Grid>
      
    </MuithemeProvider>
    </Router>
  )  
}

export default App;
