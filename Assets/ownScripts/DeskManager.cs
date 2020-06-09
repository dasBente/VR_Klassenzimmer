using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskManager : MonoBehaviour
{
    public Transform LeftSlot, RightSlot;

    private void Start()
    {
        BehaviourController left = LeftSlot.GetComponentInChildren<BehaviourController>(false);
        BehaviourController right = RightSlot.GetComponentInChildren<BehaviourController>(false);
        
        // TODO this is a lazy solution, ideally these should refer to the partners head for look-at's
        left.SetConversationPartner(RightSlot);
        right.SetConversationPartner(LeftSlot);
    }
}
