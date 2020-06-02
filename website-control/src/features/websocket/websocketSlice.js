import { createSlice } from '@reduxjs/toolkit'

export const websocketSlice = createSlice({
  name: 'websocket',
  initialState: {
    status: 'closed', // TODO other interesting states?
    error: ''
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
  socket = new WebSocket("ws://localhost:12000/SockServer")

  socket.onopen = e => {
    dispatch(connectionState('connected'))
    requestBootstrapping()(dispatch)
  }

  socket.onmessage = e => {
    dispatch(connectionState('connected'))
    const action = JSON.parse(e.data)
    const fn = handleMessage[action.type]
    if (fn) {
      fn(action, dispatch)
    } else {
      dispatch(socketError('Unbekannter Aktionstyp ' + action.type))
      dispatch(connectionState('warning'))
    }
  }

  socket.onerror = e => {
    dispatch(connectionState('error'))
    dispatch(socketError(e.message))
  }

  socket.onclose = e => {
    dispatch(connectionState('closed'))
  }
}

export const statusSelector = ({ websocket }) => websocket.status
export const errorSelector = ({ websocket }) => websocket.error

export default websocketSlice.reducer
