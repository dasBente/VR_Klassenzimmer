using System;
using UnityEngine;

/// <summary>
/// Type ceiling for JSON data
/// </summary>
[Serializable]
public class JsonData {
    //public string type = "";

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
