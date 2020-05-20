using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract component to genrate students to be placed in a classroom.
/// </summary>
public abstract class StudentPlacer : MonoBehaviour
{
    /// <summary>
    /// Generates a new student through some means and places them.
    /// </summary>
    /// <param name="chair">Attachment to parent the student under.</param>
    /// <returns>Newly generated student instance.</returns>
    public abstract GameObject NextStudent(Transform chair);

    /// <summary>
    /// Used by editor to update component-specific information.
    /// </summary>
    public virtual void EditorUpdateHook() { }
}
