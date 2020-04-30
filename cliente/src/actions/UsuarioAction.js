import HttpClient from '../services/HttpClient';

export const registrarUsuario = usuario => {
  return new Promise((resolve, reject) => {
      HttpClient.post('/Auth/Register',usuario).then(response => {
          resolve(response);
      })
  })
}

