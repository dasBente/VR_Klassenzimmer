using UnityEngine;
using System;

[Serializable]
public class BootstrapResponse : JsonData
{
    public string type = "bootstrap";
    public string[] students;

    public BootstrapResponse(string[] students)
    {
        this.students = students;
    }

    public string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }
}
