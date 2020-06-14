using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    private EventQueue<string, string, string> queue;

    private Transform conversationPartner;
    private Animator animator;
    private LookAt lookat;
    private StudentController sc;
    private string expectedBehaviour;

    public static SocketEventHandler Handler;

    private void Start()
    {
        sc = GetComponent<StudentController>();
        animator = sc.Model.GetComponent<Animator>();
        lookat = GetComponent<LookAt>();

        queue = new EventQueue<string, string, string>(s => s, s => s);

        queue.RegisterCallback("idle", GoodBehaviour(0));
        queue.RegisterCallback("chatting", _ => animator.SetTrigger("Chatting"));
        queue.RegisterCallback("hitting", _ => animator.SetTrigger("Hitting"));
        queue.RegisterCallback("eating", _ => animator.SetTrigger("Eating"));
        queue.RegisterCallback("drinking", _ => animator.SetTrigger("Drinking"));
        queue.RegisterCallback("writing", GoodBehaviour(1));
        queue.RegisterCallback("question", GoodBehaviour(2));
        queue.RegisterCallback("raiseArm", GoodBehaviour(3));
        queue.RegisterCallback("behave", _ => animator.SetTrigger("Idle"));
        queue.RegisterCallback("throwing", _ => animator.SetTrigger("Throwing"));
        queue.RegisterCallback("starring", _ => animator.SetTrigger("Starring"));
        queue.RegisterCallback("lethargic", _ => animator.SetTrigger("Lethargic"));

    }

    private EventQueue<string, string, string>.Handler GoodBehaviour(int id)
    {
        return s =>
        {
            animator.SetInteger("GoodBehaviour", id);
            animator.SetTrigger("Idle");
            expectedBehaviour = s;
        };
    }

    /// <summary>
    /// Given a partner for conversation, sets the respective attribute and calculates direction.
    /// </summary>
    /// <param name="partner">Conversation partner student object</param>
    public void SetConversationPartner(Transform partner)
    {
        conversationPartner = partner;
        animator.SetBool("Front", transform.position.z < conversationPartner.position.z + 2f);
        animator.SetBool("Left", Vector3.Dot(transform.right, partner.position - transform.position) > 0);
    }

    /// <summary>
    /// Let's student play out a given disruption.
    /// </summary>
    /// <param name="disruption">identifier of the respective disturbance</param>
    public void DisruptClass(string disruption)
    {
        queue.Enqueue(disruption);
        queue.ProcessAll();
    }

    public void DisruptClass(string disruption, JsonData response)
    {
        DisruptClass(disruption);
        Handler.Respond(disruption, response);
    }

    void OnTriggerEnter(Collider other)
    {
        if (MenuDataHolder.isAutomaticIntervention) // TODO check if currently well behaved somehow
        {
            MenuDataHolder.MisbehaviourSolved++;
            lookat.Active = true;
            DisruptClass("behave", new Behave(sc.Id, expectedBehaviour));
        }
    }

    void PlayAudio()
    {
        animator.GetBehaviour<PlayAudioVariation>()?.PlayAudio(sc.IsMale);
    }
}
