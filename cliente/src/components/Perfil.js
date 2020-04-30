import React, { useEffect, useState } from 'react';
import axios from 'axios';

function Perfil(props) {

  const [paises, getPaises] = useState([]);
  const [status, cambiarStatus] = useState(false);

  useEffect(() => {
    axios.get('https://restcountries.eu/rest/v2/all')
      .then(resultado => {
          getPaises(resultado.data);
          cambiarStatus(true); 
      })
      .catch(error => {
        cambiarStatus(true);
      });
    
  }, []);

  if(status) {
    return (
      <ul>
        {paises.map((paises, indice) => 
          <li key={indice}>{paises.name}</li>
        )}
      </ul>
    );
  } else {
    return (
      <h1>Cargando la lista...</h1>
    )
  }
}

export default Perfil;