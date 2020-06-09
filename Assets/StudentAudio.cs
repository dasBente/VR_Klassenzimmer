using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAudio : MonoBehaviour
{
    private StudentController sc;
    private Animator animator;
    private void Start()
    {
        sc = GetComponent<StudentController>();
        animator = GetComponent<Animator>();
    }

    public void PlayAudio()
    {
        // Delegate clip selection to a script in the current animator state
        animator.GetBehaviour<PlayAudioVariation>().PlayAudio(sc.IsMale);
    }
}
