using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptanceController : MonoBehaviour
{
    private string lastGoodBehaviour = "breathing";
    private bool sitsLeft = false;

    private Transform conversationPartner;
    private Animator animator;
    private LookAt lookat;
    private StudentController sc;

    private SocketEventHandler handler;

    private void Start()
    {
        sc = GetComponent<StudentController>();
        animator = GetComponent<Animator>();
        lookat = GetComponent<LookAt>();
    }

    /// <summary>
    /// Registers socket event handler for communication purposes.
    /// </summary>
    /// <param name="handler">Socket event handler instance</param>
    public void RegisterHandler(SocketEventHandler handler)
    {
        this.handler = handler;
    }

    /// <summary>
    /// Given a partner for conversation, sets the respective attribute and calculates direction.
    /// </summary>
    /// <param name="partner">Conversation partner student object</param>
    public void SetConversationPartner(Transform partner)
    {
        conversationPartner = partner;

        // This should work? TODO verify
        sitsLeft = Vector3.Dot(transform.right, partner.position - transform.position) < 0;
    }

    /// <summary>
    /// Let's student play out a given disruption.
    /// </summary>
    /// <param name="disruption">identifier of the respective disturbance</param>
    public void DisruptClass(string disruption)
    {
        sc.Behaviour = disruption;

        switch (disruption)
        {
            case "breathing":
            case "writing":
                lastGoodBehaviour = disruption;
                lookat.Active = true;
                break;
            case "chatting":
                if (Mathf.Abs(transform.position.x - conversationPartner.position.x) < 1.5)
                    disruption += transform.position.z < conversationPartner.position.z + 2f ? "For" : "Back";
                disruption += sitsLeft ? "L" : "R";
                break;
            case "hit":
                disruption += sitsLeft ? "L" : "R";
                break;
        }

        animator.SetTrigger(disruption);
    }

    public void TriggerLastGoodBehaviour()
    {
        MenuDataHolder.MisbehaviourSolved++;
        lookat.Active = true;
        animator.SetTrigger(lastGoodBehaviour);
        handler.Respond("behave", new Behave(sc.Id, lastGoodBehaviour));
    }

    void OnTriggerEnter(Collider other)
    {
        if (MenuDataHolder.isAutomaticIntervention)
        {
            TriggerLastGoodBehaviour();
        }
    }
}
