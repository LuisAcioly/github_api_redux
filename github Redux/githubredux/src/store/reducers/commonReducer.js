const defaultState = {
    repositories: [],
    unloaded: true,
};

function commonRoot(state = defaultState, action) {
    // The reducer normally looks at the action type field to decide what happens
    switch (action.type) {
      case 'SAVE_REPOSITORIES': 

        return {
            ...state,
            repositories: action.repositories,
            unloaded: action.unloaded,
        }
        case 'FAVORITE': 
        return {
            ...state,
            repositories: action.repositories,
        }

      default:
        // If this reducer doesn't recognize the action type, or doesn't
        // care about this specific action, return the existing state unchanged
        return state
    }
}

export default commonRoot;
