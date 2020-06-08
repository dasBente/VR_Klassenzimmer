using UnityEngine;

public class ThrowObject : MonoBehaviour {
    GameObject throwable;
    private Transform releasePoint;

    public void Start()
    {
        throwable = Resources.Load<GameObject>("PaperBall2");
        
        releasePoint = transform.Find("mixamorig:Hips").transform.
            GetChild(2).    //Spine
            GetChild(0).    //Spine1
            GetChild(0).    //Spine2
            GetChild(2).    //RightShoulder
            GetChild(0).    //RightArm
            GetChild(0).    //RightForeArm
            GetChild(0).    //RightHand
            GetChild(1).    //RightHandMiddle1
            GetChild(0);    //RightHandMiddle2
    }

    public void ThrowBall()
    {
        throwable = Instantiate(throwable, releasePoint.position, Quaternion.identity);
        throwable.GetComponent<BallScript>().ReleaseMe();
    }

}
