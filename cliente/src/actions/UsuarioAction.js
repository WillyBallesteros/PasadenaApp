import HttpClient from "../services/HttpClient";
import axios from 'axios';

const instancia = axios.create();
instancia.CancelToken = axios.CancelToken;
instancia.isCancel = axios.isCancel;

export const registrarUsuario = (usuario) => {
  return new Promise((resolve, eject) => {
    instancia.post("/Auth/Register", usuario).then((response) => {
      resolve(response);
    });
  });
};

export const obtenerUsuarioActual = (dispatch) => {
  return new Promise((resolve, eject) => {
    HttpClient.get("/Auth/GetCurrentUser").then((response) => {
      if (response.data.result && response.data.result.imagenPerfil) {
        let fotoPerfil = response.data.result.imagenPerfil;
        const nuevoFile =
          "data:image/" + fotoPerfil.extension + ";base64," + fotoPerfil.data;
        response.data.result.imagenPerfil = nuevoFile;
      }
      if (response.data.result) {
        dispatch({
          type: "INICIAR_SESION",
          sesion: response.data.result,
          autenticado: true,
        });
      }
      resolve(response);
    });
  });
};

export const actualizarUsuario = (usuario, dispatch) => {
  return new Promise((resolve, eject) => {
    HttpClient.put("/Auth/UpdateUser", usuario)
      .then((response) => {
        if (response.data.result && response.data.result.imagenPerfil) {
          let fotoPerfil = response.data.result.imagenPerfil;
          const nuevoFile =
            "data:image/" + fotoPerfil.extension + ";base64," + fotoPerfil.data;
          response.data.result.imagenPerfil = nuevoFile;
        }

        dispatch({
          type: "INICIAR_SESION",
          sesion: response.data.result,
          autenticado: true,
        });

        resolve(response);
      })
      .catch((error) => {
        resolve(error.response);
      });
  });
};

export const loginUsuario = (usuario, dispatch) => {
  return new Promise((resolve, eject) => {
    instancia.post("/Auth/Login", usuario).then(response => {
      
      if (response.data.result && response.data.result.imagenPerfil) {
        let fotoPerfil = response.data.result.imagenPerfil;
        const nuevoFile =
          "data:image/" + fotoPerfil.extension + ";base64," + fotoPerfil.data;
        response.data.result.imagenPerfil = nuevoFile;
      }

      dispatch({
        type: "INICIAR_SESION",
        sesion : response.data.result,
        autenticado : true
      })
      
      resolve(response);
    }).catch(error => {
      resolve(error.response);
    })
  });
};
