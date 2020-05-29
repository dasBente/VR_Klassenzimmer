using System.Collections.Generic;
using UnityEngine;

public class SocketEventHandler : MonoBehaviour
{
    private Queue<SocketEvent> eventQueue = new Queue<SocketEvent>();

    private Dictionary<string, Handler> eventHandlers = new Dictionary<string, Handler>();

    public delegate void Handler(string data);

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
}
