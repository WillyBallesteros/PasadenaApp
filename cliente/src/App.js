import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { ThemeProvider as MuithemeProvider } from "@material-ui/core/styles";
import { Grid, Snackbar } from "@material-ui/core";

import theme from "./theme/theme";
import Login from "./components/security/Login";
import AppNavBar from "./components/navegacion/AppNavBar";
import PerfilUsuario from "./components/security/PerfilUsuario";
import RegistrarUsuario from "./components/security/RegistrarUsuario";
import { useStateValue } from "./context/store";
import { obtenerUsuarioActual } from "./actions/UsuarioAction";
import RutaSegura from "./components/navegacion/RutaSegura";

function App() {
  const [{ openSnackbar }, dispatch] = useStateValue();

  const [iniciaApp, setIniciaApp] = useState(false);

  useEffect(() => {
    if (!iniciaApp) {
      obtenerUsuarioActual(dispatch)
        .then((response) => {
          setIniciaApp(true);
        })
        .catch((error) => {
          setIniciaApp(true);
        });
    }
  }, [iniciaApp]);

  return iniciaApp === false ? null : (
    <React.Fragment>
      <Snackbar
        anchorOrigin={{vertical: "bottom", horizontal:"center"}}
        open={openSnackbar ? openSnackbar.open : false}
        autoHideDuration={3000}
        ContentProps={{"aria-describedby" : "message-id"}}
        message={ 
          <span id="message-id">{openSnackbar ? openSnackbar.mensaje : ""}</span> 
        }
        onClose= {() => 
          dispatch({
            type : 'OPEN_SNACKBAR',
            openMensaje: {
              open: false,
              mensaje: ""
            }
          })
        }
      >
        
      </Snackbar>  
      <Router>
        <MuithemeProvider theme={theme}>
          <AppNavBar />
          <Grid container>
            <Switch>
              <Route exact path="/auth/login" component={Login} />
              <Route
                exact
                path="/auth/registrar"
                component={RegistrarUsuario}
              />
              <RutaSegura 
                  exact
                  path = "/auth/perfil"
                  component = {PerfilUsuario}
              />
              <RutaSegura 
                  exact
                  path = "/"
                  component = {PerfilUsuario}
              />
            </Switch>
          </Grid>
        </MuithemeProvider>
      </Router>
    </React.Fragment>
  );
}

export default App;
