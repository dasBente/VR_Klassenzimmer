using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var delay = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length * Random.value;
        animator.Play("breath", 0, delay);
    }
}
