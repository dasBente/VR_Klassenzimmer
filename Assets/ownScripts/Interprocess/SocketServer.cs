using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

public class SocketServer : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        char[] sep = { ';' }; // ??? why can't you just be normal C#
        string[] action = e.Data.Split(sep, 2);

        Debug.Log(e.Data);

        // TODO: translate payload depending on action[0]
        // TODO: execute a function depending on action[0], which gets new object from above

        // TODO: automize this somehow
        switch (action[0])
        {
            case "disrupt":
                Debug.Log("[event] disrupt");
                Disruption req = JsonUtility.FromJson<Disruption>(action[1]);
                // TODO: Rework disruption system
                break;

            case "bootstrap":
                Debug.Log("[event] bootstrap");
                BootstrapResp b = BootstrapResp.FromStudents(GameObject.FindGameObjectsWithTag("students"));
                Debug.Log(b.students);
                string resp = JsonUtility.ToJson(b);
                Send(resp);
                break;
        }
    }

    public static WebSocketServer HostServer()
    {
        var wssv = new WebSocketServer("ws://localhost:10000");
        wssv.AddWebSocketService<SocketServer>("/SockServer");
        
        wssv.Start();

        Debug.Log("Start Socket Server");
        return wssv;
    }

    protected override void OnOpen()
    {
        
    }
}
