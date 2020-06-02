using UnityEngine;
using System;

[Serializable]
public class BootstrapResponse : JsonData
{
    public string type = "bootstrap";
    public Student[] students;

    public BootstrapResponse(Student[] students)
    {
        this.students = students;
    }

    public string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }
}
