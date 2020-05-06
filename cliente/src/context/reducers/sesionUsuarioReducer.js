// se llama igual que la que esta en initialState pero no es la misma, solo que la data se va a almacenar alla
export const initialState = {
    usuario: {
        nombres: '',
        apellidos: '',
        email: '',
        telefono: '',
        tipoDocumentoId: '',
        numeroCedula: '',
        ciudadId: '',
        puntoVentaId: '',
        imagen : ''
    },
    autenticado: false
}

const sesionUsuarioReducer = (state = initialState, action) => {
    switch(action.type) {
        case "INICIAR_SESION" : 
            return {
                ...state,
                usuario : action.sesion,
                autenticado : action.autenticado
            };
        case "SALIR_SESION" :
            return {
                ...state,
                usuario: action.nuevoUsuario,
                autenticado: action.autenticado
            };
        case "ACTUALIZAR_USUARIO" :
            return {
                ...state,
                usuario : action.nuevoUsuario,
                autenticado: action.autenticado
            }
        default : return state;
    }
};

export default sesionUsuarioReducer;