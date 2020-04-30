import React , {useState} from 'react';
import {ThemeProvider as MuithemeProvider} from "@material-ui/core/styles";
import theme from './theme/theme';
import PerfilUsuario from './components/security/PerfilUsuario';
import RegistrarUsuario from './components/security/RegistrarUsuario';

function App() {
  
  return (
    <MuithemeProvider theme={theme}>
      <PerfilUsuario/>
    </MuithemeProvider>
    
  )  
}

export default App;
