import { createStore, compose, combineReducers } from 'redux'
import * as rootReducer from './reducers'

export default () => {
  const store = createStore(
    combineReducers(rootReducer),
    compose(
      /* Debuggin tool */
      window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
    )
  )

  return store
}
