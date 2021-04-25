import { createStore, combineReducers } from 'redux';
import appReducer from './reducers'

const rootReducer = combineReducers({
    repositories: appReducer,
});

const store = createStore(rootReducer);

export default store;