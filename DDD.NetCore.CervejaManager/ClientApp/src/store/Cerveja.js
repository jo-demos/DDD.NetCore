"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
exports.actionCreators = {
    requestCervejas: function () { return function (dispatch, getState) {
        // Only load data if it's something we don't already have (and are not already loading)
        debugger;
        var appState = getState();
        if (appState && appState.cervejas) {
            fetch("api/cerveja")
                .then(function (response) { return response.json(); })
                .then(function (data) {
                dispatch({ type: 'RECEIVE_CERVEJA', cervejas: data });
            });
            dispatch({ type: 'REQUEST_CERVEJA' });
        }
    }; }
};
// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
var unloadedState = { cervejas: [], isLoading: false };
exports.reducer = function (state, incomingAction) {
    if (state === undefined) {
        return unloadedState;
    }
    var action = incomingAction;
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
//# sourceMappingURL=Cerveja.js.map