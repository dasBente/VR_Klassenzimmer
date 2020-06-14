using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    protected Animator Animator;
    public bool Active = true;

    public float IKIntensity = 0.8f;

    public static Transform Target { get; set; }

    private void Start()
    {
        Animator = transform.GetChild(0).gameObject.GetComponent<Animator>();

        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("Teacher").GetComponent<TeacherController>().LookAtTarget;
    }

    void OnAnimatorIK()
    {
        if (Active)
        {
            if (Target != null)
            {
                Animator.SetLookAtWeight(IKIntensity);        //the parameter of this function sets the percentage of "effort" the avatar uses to look in direction of lookObj
                Animator.SetLookAtPosition(Target.position);// -lookObjOffset);
            }
            else // Assume neutral position if no target is given
            {
                Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                Animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                Animator.SetLookAtWeight(0);
            }
        }
    }

    private void Update()
    {
        if (Active)
        {
            Active = true;

            if (Target != null)
            {
                Vector3 student2teacher = transform.position - Target.position;
                Vector3 viewDir = transform.forward;

                IKIntensity = Vector3.Angle(viewDir, student2teacher) > 100f ? 1.0f : 0.0f;
            }
        }
    }
}
