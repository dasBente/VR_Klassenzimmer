using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Generates students for all available Attachment points.
/// </summary>
[CustomEditor(typeof(StudentPlacer), true)]
public class StudentPlacerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Place Students"))
        {
            GenerateStudents();
        }
    }

    /// <summary>
    /// Generates a student for every attachment point.
    /// </summary>
    public void GenerateStudents()
    {
        foreach (GameObject student in GameObject.FindGameObjectsWithTag("Student")) DestroyImmediate(student);

        StudentPlacer sp = (StudentPlacer) target;
        sp.EditorUpdateHook();

        foreach (GameObject chair in GameObject.FindGameObjectsWithTag("StudentAttachmentPoint")) sp.NextStudent(chair.transform);
    }
}
