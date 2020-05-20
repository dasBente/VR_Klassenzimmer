using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAttributes : MonoBehaviour
{
    public float WhenToBlink;
    public string LastGoodBehaviour;
    public bool isDistorting;
    public float TimeDelayToLastMisbehaviour;
    public float ChanceToMisbehave;

    void Start()
    {
        LastGoodBehaviour = "breathing";
        isDistorting = false;
        WhenToBlink = Random.Range(5, 15);
        TimeDelayToLastMisbehaviour = 0;
        ChanceToMisbehave = 0.5f;
    }

}
