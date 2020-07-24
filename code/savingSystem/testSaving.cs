using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSaving : MonoBehaviour
{
    public float timer = 15f;
    public placebuildings placeBuildings;
    public List<float> buildingsPosX = new List<float>();
    public List<float> buildingsPosY = new List<float>();
    public List<string> buildingsName = new List<string>();

    void Start()
    {
        savingBuildPos buildingData = saving.loadPosOfBuilding();
        placeBuildings.destroyAllBuildings();
        placeBuildings.tpos = new Vector3[1000];
        //put the text file into the game
        for (int i = 0; i < buildingData.buildingsNames.Length; i++)
        {
            buildingsPosX.Add(buildingData.posOfBuildingX[i]);
            buildingsPosY.Add(buildingData.posOfBuildingY[i]);
            buildingsName.Add(buildingData.buildingsNames[i]);
            placeBuildings.makeBuilding(buildingsPosX[i], buildingsPosY[i], buildingsName[i]);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 60f;
            //calls the function there creates the list for one sec
            placeBuildings.takeOutThePos();

            //taking the list from placebuildings 
            buildingsPosX = placeBuildings.buildingsPosX;
            buildingsPosY = placeBuildings.buildingsPosY;
            buildingsName = placeBuildings.Names;
            //gives saving this so that will mean that the saving scripts gets the arrays
            saving.savePosOfBuilding(this);
        }
        //in game content
        if (Input.GetKeyDown(KeyCode.L))
        {            
            savingBuildPos buildingData = saving.loadPosOfBuilding();
            placeBuildings.destroyAllBuildings();
            placeBuildings.tpos = new Vector3[1000];
            //put the text file into the game
            for (int i = 0; i < buildingData.buildingsNames.Length; i++)
            {
                buildingsPosX.Add(buildingData.posOfBuildingX[i]);
                buildingsPosY.Add(buildingData.posOfBuildingY[i]);
                buildingsName.Add(buildingData.buildingsNames[i]);
                placeBuildings.makeBuilding(buildingsPosX[i], buildingsPosY[i], buildingsName[i]);
            }
        }
        //gives the system the data
        else if (Input.GetKeyDown(KeyCode.P))
        {
            //calls the function there creates the list for one sec
            placeBuildings.takeOutThePos();

            //taking the list from placebuildings 
            buildingsPosX = placeBuildings.buildingsPosX;
            buildingsPosY = placeBuildings.buildingsPosY;
            buildingsName = placeBuildings.Names;
            //gives saving this so that will mean that the saving scripts gets the arrays
            saving.savePosOfBuilding(this);
            
        }
    }
}
