using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventJson
{
    public string type;
    public object payload;

    public static EventJson FromJson(string json)
    {
        return JsonUtility.FromJson<EventJson>(json);
    }
}
