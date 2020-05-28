using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptanceController : MonoBehaviour
{
    private bool isDisrupting = false;
    private float timeSinceLastDisruption = 0f;
    private float chanceToMisbehave = 0.5f;
    private float nextBlink;
    private string lastGoodBehaviour = "breathing";
    private bool sitsLeft = false;

    private Transform conversationPartner;
    private Animator animator;
    private LookAt lookat;
    private StudentController sc;

    private Collider interventionTrigger;

    private void Start()
    {
        sc = GetComponent<StudentController>();
        animator = GetComponent<Animator>();
        lookat = GetComponent<LookAt>();
        nextBlink = Random.Range(5, 15);
    }

    void Update()
    {
        
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
        chanceToMisbehave = 0f;
        timeSinceLastDisruption = 0f;
        sc.Behaviour = disruption;

        switch (disruption)
        {
            case "breathing":
            case "writing":
                lastGoodBehaviour = disruption;
                isDisrupting = false;
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
        isDisrupting = false;
        MenuDataHolder.MisbehaviourSolved++;
        lookat.Active = true;
        animator.SetTrigger(lastGoodBehaviour);
    }

    void OnTriggerEnter(Collider other)
    {
        if (MenuDataHolder.isAutomaticIntervention)
        {
            TriggerLastGoodBehaviour();
        }
    }
}
