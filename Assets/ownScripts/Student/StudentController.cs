﻿using UnityEngine;
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

    private float AwarenessRange = 1.4f;

    public string Behaviour = "idle";

    private void Start()
    {
        Behaviour = "idle";
    }

    /// <summary>
    /// Generate and fill out a new student instance.
    /// </summary>
    /// <param name="model">Prefab of the student model.</param>
    /// <param name="chair">Transform of a attachment point to parent the student under.</param>
    /// <returns>Newly created student instance.</returns>
    public static GameObject GenerateStudentModel(GameObject model, Transform chair)
    {
        if (model == null) throw new System.NullReferenceException("No model for student provided.");
        GameObject student = Instantiate(model, chair);

        // TODO find a better solution for this (maybe via another layer of indirection?)
        // Attach common components to students

        StudentController sc = student.AddComponent<StudentController>();

        student.AddComponent(typeof(BehaviourController));

        //Add all scripts to students to give them kinda individual characters
        student.AddComponent(typeof(MixamoAttechment));
        student.AddComponent(typeof(playSound));
        student.AddComponent(typeof(ThrowObject));
        student.AddComponent(typeof(LookAt));

        SphereCollider col = student.AddComponent<SphereCollider>();
        col.radius = sc.AwarenessRange;
        col.center = new Vector3(0.0022482f, 0.337685f, 0.0786477f);
        col.isTrigger = true;

        AudioSource audisource = student.AddComponent<AudioSource>();
        audisource.loop = false;
        audisource.playOnAwake = false;
        audisource.spatialBlend = 1;
        audisource.rolloffMode = AudioRolloffMode.Linear;
        audisource.maxDistance = 10;

        return student;
    }

    public static BootstrapResponse ClassToJson()
    {
        Debug.Log("Hallo");
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
