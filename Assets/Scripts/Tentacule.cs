using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacule : MonoBehaviour
{
    //Get the line renderer comp and the number of points of the tail
    public int length;
    public LineRenderer lineRend;

    public Vector3[] segmentPoses;
    public Vector3[] segmentV;
    public float mytry;

    //Get the transforme of the object parent
    public Transform targetDir;

    public float smoothSpeed;

    //Gives the distance between every points of the tail
    public float targetDist;

    public float trailSpeed; 

    public void setLength(int newlength)
    {
        length += newlength;
        Debug.Log("Tail grow");
        lineRend.positionCount = length;
        Vector3[] newsegmentPoses = new Vector3[length];
        Vector3[] newsegmentV = new Vector3[length];
        for (int i = 0; i < (length - newlength); i++)
        {
            newsegmentPoses[i] = segmentPoses[i];
            newsegmentV[i] = segmentPoses[i];
        }
        segmentPoses = newsegmentPoses;
        segmentV = newsegmentV;
    }

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        //Gives a position to every points of the tail
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], (segmentPoses[i - 1] + targetDir.right * targetDist) / mytry, ref segmentV[i], smoothSpeed + i / trailSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}
