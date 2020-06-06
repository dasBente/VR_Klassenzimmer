using System.Collections.Generic;
using UnityEngine;

public class SocketEventHandler : MonoBehaviour
{
    public string SocketHost = "localhost";
    public int SocketPort = 10000;
    public string SocketPath = "SockServer";

    private Queue<SocketEvent> eventQueue = new Queue<SocketEvent>();

    private Dictionary<string, Handler> eventHandlers = new Dictionary<string, Handler>();

    public delegate void Handler(string data);

    private SocketServer socket;

    private void Start()
    {
        socket = SocketServer.HostServer(SocketHost, SocketPort, SocketPath);
        socket.SubscribeEventHandler(this);
    }

    public void Respond(string type, JsonData response)
    {
        socket.Emit(new RequestJson(type, response));
    }

    public void RegisterHandler(string key, Handler handler)
    {
        eventHandlers.Add(key, handler);
    }

    public void EnqueueEvent(string type, string data)
    {
        eventQueue.Enqueue(new SocketEvent(type, data));
    }

    public void ProcessEvents()
    {
        // TODO Check performance impact
        // possible solutions if performance tanks:
        //   - introduce max number of events to handle at once
        //   - introduce polling rate (i.e. only poll every N ms)

        while (eventQueue.Count > 0)
        {
            SocketEvent s = eventQueue.Dequeue();

            Handler h;

            if (!eventHandlers.TryGetValue(s.Type, out h))
                throw new KeyNotFoundException("Please provide a handler for event " + s.Type);

            h(s.Data);
        }
    }

    private void Update()
    {
        ProcessEvents(); // TODO constrain execution somehow?
    }
}
