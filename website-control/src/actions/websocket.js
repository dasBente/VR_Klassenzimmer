const socket = new WebSocket('ws://localhost:10000/SockServer')

/*
export const emit = (action) => {
  socket.send(action.type + ';' + JSON.stringify(action.payload))
}
*/

export const initSocket = () => {
  socket.onopen = e => {
    console.log('[open] Connection established!')
    console.log('Sending to server')

    socket.send('bootstrap;{}')
  }

  socket.onmessage = e => {
    console.log(e.data)
  }

  socket.onclose = e => {
    console.log('Connection closed')
  }

  socket.onerror = e => {
    console.error(`[error] ${e.message}`)
  }
}
