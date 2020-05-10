import sesionUsuarioReducer from './sesionUsuarioReducer';
import openSnackbarReducer from './openSnackbarReducer';
import searchProductReducer from './searchProductReducer';

export const mainReducer = ({sesionUsuario, openSnackbar, searchProduct}, action) => {
    return {
        sesionUsuario : sesionUsuarioReducer(sesionUsuario, action),
        openSnackbar : openSnackbarReducer(openSnackbar, action),
        searchProduct : searchProductReducer(searchProduct, action),
    }
}