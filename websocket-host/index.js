const io = require('socket.io')
const server = io.listen(10000)

const seqByClient = new Map()

server.on('connection', socket => {
  console.log(`Client connected [id=${socket.id}]`)
  seqByClient.set(socket, 1)

  socket.on('disconnect', () => {
    seqByClient.delete(socket)
    console.info(`Client gone [id=${socket.id}]`)
  })
})

setInterval(() => {
  for (const [client, sequenceNumber] of seqByClient.entries()) {
    client.emit('seq-num', sequenceNumber)
    seqByClient.set(client, sequenceNumber + 1)
  }
}, 1000)
