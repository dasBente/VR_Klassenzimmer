import { createSlice } from '@reduxjs/toolkit'
import { init } from '../classState/studentsSlice'

export const websocketSlice = createSlice({
  name: 'websocket',
  initialState: {
    status: 'closed', // TODO other interesting states?
    error: ''
  },
  reducers: {
    connectionState: (state, action) => ({ ...state, status: action.payload }),
    socketError: (state, action) => ({ ...state, error: action.payload })
  }
})

export const { connectionState, socketError } = websocketSlice.actions

export const toSocketAction = action =>
  `${action.type};${JSON.stringify({ ...action, type: undefined })}`

let socket

export const requestBootstrapping = () => {
  console.log("[socket] Requesing to bootstrap classroom.")
  socket.send(toSocketAction({ type: 'bootstrap' }))
}

const handleMessage = (action, dispatch) => {
  switch (action.type) {
    case 'bootstrap':
      dispatch(init(action.students.map(s => JSON.parse(s))))
      break;
    default:
      dispatch(socketError('Unbekannter Aktionstyp ' + action.type))
      dispatch(connectionState('warning'))
      break;
  }
}

export const initSocket = () => dispatch => {
  if (socket) return // Don't run this twice

  socket = new WebSocket("ws://localhost:10000/SockServer")

  socket.onopen = e => {
    console.log("[socket] Connection established!")
    dispatch(connectionState('connected'))
    requestBootstrapping()
  }

  socket.onmessage = e => {
    const action = JSON.parse(e.data)
    handleMessage(action, dispatch)
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
