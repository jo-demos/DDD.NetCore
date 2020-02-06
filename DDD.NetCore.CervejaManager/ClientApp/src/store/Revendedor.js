"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
exports.actionCreators = {
    requestRevendedors: function () { return function (dispatch, getState) {
        // Only load data if it's something we don't already have (and are not already loading)
        debugger;
        var appState = getState();
        if (appState && appState.revendedores) {
            fetch("api/revendedor")
                .then(function (response) { return response.json(); })
                .then(function (data) {
                dispatch({ type: 'RECEIVE_REVENDEDOR', revendedores: data });
            });
            dispatch({ type: 'REQUEST_REVENDEDOR' });
        }
    }; }
};
// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
var unloadedState = { revendedores: [], isLoading: false };
exports.reducer = function (state, incomingAction) {
    if (state === undefined) {
        return unloadedState;
    }
    var action = incomingAction;
    switch (action.type) {
        case 'REQUEST_REVENDEDOR':
            return {
                revendedores: state.revendedores,
                isLoading: true
            };
        case 'RECEIVE_REVENDEDOR':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                revendedores: action.revendedores,
                isLoading: false
            };
        default:
            return state;
    }
};
//# sourceMappingURL=Revendedor.js.map