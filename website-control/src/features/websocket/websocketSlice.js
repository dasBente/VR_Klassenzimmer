import { createSlice } from '@reduxjs/toolkit'

export const websocketSlice = createSlice({
  name: 'websocket',
  initialState: {
    status: 'closed', // TODO other interesting states?
    error: { type: 'none', msg: '' }
  },
  reducers: {
    connectionState: (state, action) => { state.connected = action.payload },
    socketError: (state, action) => { state.error = action.payload }
  }
})

export const { connectionState, socketError } = websocketSlice.actions

let socket

export const toSocketAction = action =>
  `${action.type};${JSON.stringify({ ...action, type: undefined })}`

export const requestBootstrapping = () => dispatch => {
  socket.send(toSocketAction({ type: 'bootstrap' }))
}

const handleMessage = {

}

export const initSocket = () => dispatch => {
  socket = new WebSocket("ws://localhost:10000/SockServer")

  socket.onopen = e => {
    requestBootstrapping()(dispatch)
  }

  socket.onmessage = e => {
    dispatch(connectionState('connected'))
    const action = JSON.parse(e.data)
    const fn = handleMessage[action.type]
    if (fn) {
      fn(action, dispatch)
    } else {
      dispatch(socketError({ type: 'warning', msg: 'Unbekannter Aktionstyp ' + action.type }))
    }
  }

  socket.onerror = e => {
    dispatch(socketError({ type: 'error', msg: e.message}))
  }

  socket.onclose = e => {
    dispatch(connectionState('closed'))
  }
}

export default websocketSlice.reducer
