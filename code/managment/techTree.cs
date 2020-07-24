
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class techTree : MonoBehaviour
{

    public buildWheelOptions BuildWheelOptions;

    public int [] buildings;

    private int tier = 0;


    void Update()
    {

        if (buildings[0] >= 1 && tier == 0)
        {
            tier++;

            BuildWheelOptions.addTier(tier);

            buildings[0] = 0;
        }
    }

    public void addBuilding(int buildingNum)
    {
        buildings[buildingNum]++;
    }

}
///