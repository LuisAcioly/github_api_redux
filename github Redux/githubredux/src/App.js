import Home from './containers/Home';
import FavList from './containers/FavList';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

function App() {
  return (
    <Router>
      <Switch>
        <Route exact path="/">
          <Home />
        </Route>
        <Route exact path="/favorites">
          <FavList />
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
