using UnityEngine;
using WebSocketSharp;
using System.Collections;

public class SocketClientTest : MonoBehaviour
{
    private void Start()
    {
        var serv = SocketServer.HostServer();

        StartCoroutine(ping());
    }

    private IEnumerator ping()
    {
        while (true)
        {
            using (var ws = new WebSocket("ws://localhost:8080/SockServer"))
            {
                yield return new WaitForSeconds(1);
                Debug.Log("Ping");

                ws.OnMessage += (sender, e) => Debug.Log("Server says " + e.Data);
                ws.Connect();
                ws.Send("TEST");
            }
        }
    }
}
