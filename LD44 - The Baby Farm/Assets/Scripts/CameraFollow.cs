using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Cam;
    public Transform Target;

    public Vector3 BottomLeftBound;
    public Vector3 TopRightBound;


    // Update is called once per frame
    void Update()
    {
        Cam.position = new Vector3(Target.position.x,Target.position.y,Cam.position.z);

        Vector3 BLB = Cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0, 0));
        if (BLB.x < BottomLeftBound.x)
        {
            Cam.position += new Vector3(BottomLeftBound.x - BLB.x, 0,0);
        }
        if ((BLB.y < BottomLeftBound.y))
        {
            Cam.position += new Vector3(0,BottomLeftBound.y - BLB.y, 0);
        }
        Vector3 TRB = Cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (TRB.x > TopRightBound.x)
        {
            Cam.position -= new Vector3(TRB.x - TopRightBound.x, 0, 0);
        }
        if ((TRB.y > TopRightBound.y))
        {
            Cam.position -= new Vector3(0,  TRB.y - TopRightBound.y , 0);
        }
    }
}
