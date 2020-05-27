import React from 'react'
import ReactDOM from 'react-dom'
import { createStore, compose, combineReducers } from 'redux'
import { Provider } from 'react-redux'
import * as rootReducer from './reducers'
import Main from './Main'

const appRoot = document.getElementById('appRoot')

const store = createStore(
  combineReducers(rootReducer),
  compose(
    /* Debuggin tool */
    window.__REDUX_DEVTOOLS_EXTENSIONS__ && window.__REDUX_DEVTOOLS_EXTENSIONS__()
  )
)

ReactDOM.render(
  <Provider store={store}>
    <Main />
  </Provider>,
  appRoot
)
