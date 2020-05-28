import { createStore, compose, combineReducers, applyMiddleware } from 'redux'
import * as rootReducer from './reducers'
import thunkMiddleware from 'redux-thunk'
import { emit, init as websocketInit } from 'actions/websocket'

export default () => {
  const middleware = [
    thunkMiddleware.withExtraArgument({ emit })
  ]

  const store = createStore(
    combineReducers(rootReducer),
    compose(
      applyMiddleware(
        ...middleware
      ),

      /* Debuggin tool */
      window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
    )
  )

  websocketInit(store)

  return store
}
