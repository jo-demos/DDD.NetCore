import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface CervejaState {
    isLoading: boolean;
    cervejas: Cerveja[];
}

export interface Cerveja {
    nome: string;
    teorAlcoolico: number;
    preco: number;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestCervejaAction {
    type: 'REQUEST_CERVEJA';
}

interface ReceiveCervejaAction {
    type: 'RECEIVE_CERVEJA';
    cervejas: Cerveja[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestCervejaAction | ReceiveCervejaAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestCervejas: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        debugger;
        const appState = getState();
        if (appState && appState.cervejas) {
            fetch(`api/cerveja`)
                .then(response => response.json() as Promise<Cerveja[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_CERVEJA', cervejas: data });
                });

            dispatch({ type: 'REQUEST_CERVEJA' });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: CervejaState = { cervejas: [], isLoading: false };

export const reducer: Reducer<CervejaState> = (state: CervejaState | undefined, incomingAction: Action): CervejaState => {
    if (state === undefined) {
        return unloadedState;
    }
    
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_CERVEJA':
            return {
                cervejas: state.cervejas,
                isLoading: true
            };
        case 'RECEIVE_CERVEJA':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                cervejas: action.cervejas,
                isLoading: false
            };
        default:
            return state;
    }
};
