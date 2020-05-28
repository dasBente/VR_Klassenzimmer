using System;
using UnityEngine;

[Serializable]
public class Student
{
    public string name;
    public int id;
    public string behaviour;

    public Student(string name, int id, string behaviour)
    {
        this.name = name;
        this.id = id;
        this.behaviour = behaviour;
    }

    public Student(StudentController sc, int id)
    {
        this.name = sc.Name;
        this.id = id;
        this.behaviour = sc.Behaviour;
    }

    public string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }
}
