import io from 'socket.io-client'
import { messageTypes, uri } from 'constants/websocket'

const socket = io(uri, { path: 'SockServer' })

export const init = ({ dispatch }) => {
  socket.connect()
  Object.keys(messageTypes).forEach(type => socket.on(type, payload => dispatch({ type, payload })))
  socket.on('connect', () => socket.send('BOOTSTRAP'))
  setInterval(() => { console.log('ping'); socket.send('PING') }, 1000)
}

export const emit = (type, payload) => socket.emit(type, payload)
