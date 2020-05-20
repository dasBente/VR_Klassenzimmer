using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassController : MonoBehaviour
{
    private GameObject[] students;

    public Dictionary<string, GameObject> PlaceDict;

    void Start()
    {
        GameObject[] students = GameObject.FindGameObjectsWithTag("Student");
        PlaceDict = new Dictionary<string, GameObject>();

        int i = 2;
        foreach (GameObject s in students) // TODO just use students instead or something like that
            PlaceDict[string.Format("{0:D2}{1}", i / 2, i % 2 == 0 ? 'L' : 'R')] = s;

        ToggleStudents(
            MenuDataHolder.StudentCount != 0 ? MenuDataHolder.StudentCount : students.Length
        );
    }

    private void ToggleStudents(int n)
    {
        foreach (GameObject student in students)
        {
            student.SetActive(n > 0);
            n--;
        }
    }
}
