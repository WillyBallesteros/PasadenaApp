// se llama igual que la que esta en initialState pero no es la misma, solo que la data se va a almacenar alla
export const initialState = {
    palabra: ""
}

const searchProductReducer = (state = initialState, action) => {
    switch(action.type) {
        
        case "ACTUALIZAR_PALABRA" :
            return {
                ...state,
                palabra : action.palabra
            }
        default : return state;
    }
};

export default searchProductReducer;