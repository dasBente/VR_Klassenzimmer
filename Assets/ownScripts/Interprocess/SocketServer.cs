using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

public class SocketServer : WebSocketBehavior
{
    private SocketEventHandler handler;

    protected override void OnMessage(MessageEventArgs e)
    {
        char[] sep = { ';' }; // ??? why can't you just be normal C#
        string[] action = e.Data.Split(sep, 2);
        handler.EnqueueEvent(action[0], action[1]);
    }

    public static SocketServer HostServer(string host, int port, string servicePath)
    {
        string uri = String.Format("ws://{0}:{1}", host, port);
        var wssv = new WebSocketServer(uri);
        SocketServer s = new SocketServer();

        wssv.AddWebSocketService("/" + servicePath, () => s); // TODO deprecated
        
        wssv.Start();
        Debug.Log("[socket] Start connection at " + uri + "/" + servicePath);
        
        return s;
    }

    public void SubscribeEventHandler(SocketEventHandler seh)
    {
        handler = seh;
    }

    public void Emit(JsonData data)
    {
        Send(JsonUtility.ToJson(data));
    }

    protected override void OnOpen()
    {
        
    }
}
