﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    private Rigidbody rigid;
    private System.Random rnd = new System.Random();
    private float rndRotation = 0;
    
    public void ReleaseMe() // TODO move all of this into ThrowObject ?
    {
        rigid = GetComponent<Rigidbody>();
        transform.parent = null;
        rigid.useGravity = true;
        rndRotation = rnd.Next(-5,5);
        transform.Rotate(-30 - rndRotation, 180 - rndRotation, -20 - rndRotation);
        rigid.AddForce(transform.forward * 500);
    }
}
