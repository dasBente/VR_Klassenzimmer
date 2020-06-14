using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : StateMachineBehaviour
{
    private AudioSource source;

    public AudioClip[] clips;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        source = animator.gameObject.GetComponent<AudioSource>();
        source.enabled = true;
    }

    public void PlayClip(string clip)
    {
        AudioClip toPlay = null;

        foreach (AudioClip c in clips)
        {
            if (c.name == clip)
            {
                toPlay = c;
                break;
            }
        }

        if (toPlay == null) throw new KeyNotFoundException("No clip titled \"" + clip + "\" exists.");
        source.PlayOneShot(toPlay);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        source.enabled = false;
    }
}
