using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generates and manages student instance logic.
/// </summary>
public class StudentController : MonoBehaviour
{
    /// <summary>
    /// Name of the student.
    /// </summary>
    public string Name;
    public string Id;
    public GameObject Model;
    public bool IsMale;

    private float AwarenessRange = 1.4f;

    public string Behaviour = "idle";

    private void Start()
    {
        Behaviour = "idle";

        Instantiate(Model, transform);
    }

    public static BootstrapResponse ClassToJson()
    {
        var students = GameObject.FindGameObjectsWithTag("Student");
        var res = new Student[students.Length];
        var i = 0;

        foreach (var student in students)
        {
            var sc = student.GetComponent<StudentController>();
            res[i] = new Student(sc);
            i++;
        }

        return new BootstrapResponse(res);
    }
}
