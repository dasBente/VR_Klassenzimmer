import React from 'react'
import ReactDOM from 'react-dom'
import { Provider } from 'react-redux'
import Main from './Main'
import store from './store'

const appRoot = document.getElementById('appRoot')

ReactDOM.render(
  <Provider store={store()}>
    <Main />
  </Provider>,
  appRoot
)
