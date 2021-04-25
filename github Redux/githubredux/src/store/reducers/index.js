import repositories from '../actions/api.action'

const defaultState = {
    repositories: repositories
};

export default function appReducer(state = defaultState, action) {
    // The reducer normally looks at the action type field to decide what happens
    switch (action.type) {
      case 'LOAD_REPOSITORIES': 
        return {
            repositories: action.repositories
        }
      default:
        // If this reducer doesn't recognize the action type, or doesn't
        // care about this specific action, return the existing state unchanged
        return state
    }
}
