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
        Debug.Log("Server read " + e.Data);
        var msg = e.Data == "BALUS"
            ? "I've been balused already..."
            : "I'm not available now.";
        Send(msg);
    }

    public static WebSocketServer HostServer()
    {
        var wssv = new WebSocketServer("ws://localhost:8080");
        wssv.AddWebSocketService<SocketServer>("/SockServer");
        wssv.Start();
        Debug.Log("Start Socket Server");
        return wssv;
    }
}
