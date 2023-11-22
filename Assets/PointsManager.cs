using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TennisBall tennisBall;
    public Text mypointsText;
    public Text otherpointsText;

    public int mypoints = 0;
    public int otherpoints = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tennisBall.transform.position.x > 17.2){
            mypoints += 1;
            mypointsText = mypoints;
        }
        if(tennisBall.transform.position.x < -17.2){
            otherpoints += 1;
            otherpointsText = otherpoints;
        }
    }
}
