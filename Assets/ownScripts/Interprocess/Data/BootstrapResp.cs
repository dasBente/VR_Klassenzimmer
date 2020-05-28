using UnityEngine;
using System;

[Serializable]
public class BootstrapResp
{
    public Student[] students;

    public static BootstrapResp FromStudents(GameObject[] students)
    {
        BootstrapResp res = new BootstrapResp();
        res.students = new Student[students.Length];
        
        for (int i = 0; i < students.Length; i++)
        {
            res.students[i] = new Student(students[i].GetComponent<StudentController>(), i);
        }
        
        return res;
    }

    public string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }
}
