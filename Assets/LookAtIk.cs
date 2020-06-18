using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtIk : StateMachineBehaviour
{
    Transform Target;
    public float IKIntensity = 0.0f;
    public float FollowThreshInDeg = 100f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Target = GameObject.FindGameObjectWithTag("Teacher")?.GetComponent<TeacherController>().LookAtTarget;  
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Target != null)
        {
            Transform t = animator.transform;
            IKIntensity = Vector3.Angle(t.forward, t.position - Target.position) > FollowThreshInDeg ? 1.0f : 0.0f;
        }
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Target != null)
        {
            animator.SetLookAtWeight(IKIntensity);        //the parameter of this function sets the percentage of "effort" the avatar uses to look in direction of lookObj
            animator.SetLookAtPosition(Target.position);
        }
        else // Assume neutral position if no target is given
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animator.SetLookAtWeight(0);
        }
    }
}
