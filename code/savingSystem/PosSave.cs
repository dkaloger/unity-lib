using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class posSave
{
    public float[] posOfCam;

    public posSave(testSaving player)
    {
        posOfCam = new float[3];
        posOfCam[0] = player.transform.position.x;
        posOfCam[1] = player.transform.position.y;
        posOfCam[2] = player.transform.position.z;
    }
}