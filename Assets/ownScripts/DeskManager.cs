using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskManager : MonoBehaviour
{
    public static int DeskCount = 0;

    public int ID;

    private void Start()
    {
        ID = DeskCount++;
        transform.Find("StudentSlotRight").gameObject.name = ID + "R";
        transform.Find("StudentSlotLeft").gameObject.name = ID + "L";
    }
}
