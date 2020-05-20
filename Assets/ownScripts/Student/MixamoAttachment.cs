using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixamoAttachment : MonoBehaviour
{
    [SerializeField]
    GameObject whatToHold = null;

    private Transform attachmentPointRight;
    private Transform attachmentPointLeft;
    private bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // Transform lookups can be expensive
        /*Transform spine = GetComponent<StudentController>().GetStudentModel().transform.
            Find("mixamorig:Hips").Find("mixamorig:Spine").
            GetChild(0).GetChild(0);

        attachmentPointRight = spine.Find("mixamorig:RightShoulder")
            .GetChild(0).GetChild(0).GetChild(0);
        attachmentPointLeft = spine.Find("mixamorig:LeftShoulder").
            GetChild(0).GetChild(0).GetChild(0);*/
    }

    public void Attach(bool right, GameObject toAttach)
    {
        Transform attachTo = isRight ? attachmentPointRight : attachmentPointLeft;
        whatToHold = Instantiate(toAttach, attachTo);
        Transform wthTrans = whatToHold.transform;

        switch (whatToHold.name)
        {
            case "Cola Can(Cola)": // TODO check if the differentiation between left/right below is even necessary
                wthTrans.localPosition = new Vector3(0.21f, 0.07f, isRight ? 0.1f : -0.1f);
                wthTrans.localEulerAngles = new Vector3(0, 0, 90);
                break;
            case "pen(Clone)":
                wthTrans.localPosition = new Vector3(0.21f, isRight ? 0.12f : 0.07f, isRight ? -0.07f : 0.01f);
                wthTrans.localEulerAngles = new Vector3(0, 0, (isRight ? 200 : 180));
                break;
        }
    }

    public void Detach()
    {
        if (whatToHold != null) Destroy(whatToHold);
        whatToHold = null;
    }
}
