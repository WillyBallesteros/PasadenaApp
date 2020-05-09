import HttpCliente from '../services/HttpClient';

export const paginacionProducto = (paginador) => {
    return new Promise((resolve, eject) => {
        HttpCliente.post('/Product/Report', paginador).then(response => {
            resolve(response);
        })
    })
}

export const paginacionProductoPorGrupo = (paginador) => {
    return new Promise((resolve, eject) => {
        HttpCliente.post('/Product/GetProductsByGroup', paginador).then(response => {
            resolve(response);
        })
    })
}