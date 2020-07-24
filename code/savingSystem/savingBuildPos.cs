using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class savingBuildPos
{

    public float[] posOfBuildingX;
    public float[] posOfBuildingY;
    public string[] buildingsNames;

    //this is an public class remember
    public savingBuildPos(testSaving Cam)
    {
        posOfBuildingX = new float[Cam.buildingsName.Count];
        posOfBuildingY = new float[Cam.buildingsName.Count];
        buildingsNames = new string[Cam.buildingsName.Count];
        // goes trough every num or string in the array/list
        for (int i = 0;i < Cam.buildingsName.Count;i++)
        {
            posOfBuildingX[i] = Cam.buildingsPosX[i];
            posOfBuildingY[i] = Cam.buildingsPosY[i];
            buildingsNames[i] = Cam.buildingsName[i];
        }
    }
}
