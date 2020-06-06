using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassController : MonoBehaviour
{
    public Dictionary<string, DisruptanceController> Students;

    void Start()
    {
        Students = new Dictionary<string, DisruptanceController>();
        SocketEventHandler handler = GetComponent<SocketEventHandler>();

        int i = 0;
        foreach (GameObject s in GameObject.FindGameObjectsWithTag("Student"))
        {
            DisruptanceController dc = s.GetComponent<DisruptanceController>();
            StudentController sc = s.GetComponent<StudentController>();
            sc.Id = "" + i; // I hate this, but it should work instead of using hash as ID
            dc.RegisterHandler(handler);
            Students.Add(sc.Id, dc);
            i++;
        }
    }

    public void DisruptClass(string behaviour)
    {
        foreach (string id in Students.Keys) DisruptClass(id, behaviour);
    }

    public void DisruptClass(Disruption d)
    {
        DisruptClass(d.students, d.behaviour);
    }

    public void DisruptClass(string[] ids, string behaviour)
    {
        foreach (string id in ids) DisruptClass(id, behaviour);
    }

    public void DisruptClass(string studentId, string behaviour)
    {
        DisruptanceController dc;
        if (!Students.TryGetValue(studentId, out dc))
            throw new KeyNotFoundException("No student registered for key " + studentId);

        dc.DisruptClass(behaviour);
    }
}
