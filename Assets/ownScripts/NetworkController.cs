﻿using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

public class NetworkController : MonoBehaviour {
    public AmbientSound AmbientController;
    private ClassController classController;

    private TcpListener Server { get; set; }

    private bool distortionRequested = false;
    private bool atmosphereChange = false;

    private String[] studentPlacesToAnimate;
    private String stoerung;
    private Thread th;
    private Socket client;

    // Use this for initialization
    void Start() {
        switch (MenuDataHolder.ChosenScene)
        {
            case 0:
            case 1:
                Application.OpenURL("file:///D:/Unity/Klassenzimmer/website-control/controlLectureScene.html");
                break;
            case 2:
                Application.OpenURL("file:///D:/Unity/Klassenzimmer/website-control/controlGroupWorkScene.html");
                break;
        }
        
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        Server = new TcpListener(localAddr, 20000);
        Server.Start();
        th = new Thread(new ThreadStart(StartListeining));
        th.Start();

        classController = GetComponent<ClassController>();
    }

    private void OnDisable()
    {
        th.Abort();
        Server.Stop();
    }

    private void OnApplicationQuit()
    {
        try
        {
            th.Abort();
        }
        catch(Exception) { }
        finally
        {
            Server.Stop();
        }
    }

    private void StartListeining()
    {
        Dictionary<string, string> map;
        Byte[] buffer = new Byte[256];
        while (true)
        {
            try
            {
                client = Server.AcceptSocket();
                if (client.Connected && !distortionRequested && !atmosphereChange)
                {
                    client.Receive(buffer);
                    map = TransformHTTPToMap(buffer);
                    client.Send(new Byte[4]);
                    string studentPlace;
                    if (map.TryGetValue("student", out studentPlace))
                    {
                        distortionRequested = true;
                        studentPlacesToAnimate = new string[studentPlace.Length / 3];
                        for (int i = 0; i < studentPlacesToAnimate.Length; i++)
                        {
                            studentPlacesToAnimate[i] = studentPlace.Substring(i * 3, 3);
                        }
                        stoerung = map["stoerung"];
                    }
                    else
                    {
                        atmosphereChange = true;
                        map.TryGetValue("noise", out stoerung);
                        Debug.Log("noise" + stoerung);
                    }
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch(NullReferenceException)
            {
                Debug.Log("Server already closed");
            }
            
        }
        
    }

    void OnAmbientChange()
    {
        AmbientController.SoundLevel(stoerung == "up");
    }

    void OnDisturbAll()
    {
        foreach (GameObject student in GameObject.FindGameObjectsWithTag("Student"))
        {
            student.GetComponent<DisruptanceController>().DisruptClass(stoerung);
        }
    }

    void OnDisturbSome()
    {
        foreach (string placeToAnimate in studentPlacesToAnimate)
        {
            Debug.Log(placeToAnimate);
            classController.PlaceDict[placeToAnimate].GetComponent<DisruptanceController>().DisruptClass(stoerung);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (distortionRequested)
        {
            distortionRequested = false;
            if (studentPlacesToAnimate[0] == "all") OnDisturbAll();
            else OnDisturbSome();
        }
        if (atmosphereChange)
        {
            atmosphereChange = false;
            OnAmbientChange();
        }
    }

    Dictionary<string, string> TransformHTTPToMap(Byte[] buffer)
    {
        Dictionary<string, string> map = new Dictionary<string, string>();
        string incomingRequest = Encoding.UTF8.GetString(buffer);
        List<string> pairs = incomingRequest.Split('=', '?', '&').ToList<string>();
        pairs.Remove(" ");
        pairs.Remove("GET /");
        for (int i = 0; i < pairs.Count / 2; i = i + 2)
        {
            map.Add(pairs[i], pairs[i + 1]);
        }
        return map;
    }
}