import HttpClient from '../services/HttpClient';

export const registrarUsuario = usuario => {
  return new Promise((resolve, reject) => {
      HttpClient.post('/Auth/Register',usuario).then(response => {
          resolve(response);
      })
  })
}

export const obtenerUsuarioActual = () => {
  return new Promise((resolve, reject) => {
    HttpClient.get('/Auth/GetCurrentUser').then(response => {
        resolve(response);
    })
  })
}

export const actualizarUsuario = usuario => {
  return new Promise((resolve, reject) => {
    HttpClient.put('/Auth/UpdateUser', usuario).then(response => {
        resolve(response);
    })
  })
}

export const loginUsuario = usuario => {
  return new Promise((resolve, reject) => {
    HttpClient.post('/Auth/Login', usuario).then(response => {
        resolve(response);
    })
  })
}

