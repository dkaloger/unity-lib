using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using  UnityEngine.Tilemaps;
public class placebuildings : MonoBehaviour
{
    bool canPlace = true;
    public bool pauseMenuOn = true;
    public GameObject destroyBuildingPos;
    public Transform[] childTrans;
    public Transform[] childTransOrders;
    public destroy[] childScripts;
    public GameObject parrentForBuildings;
    public GameObject parrentForOrders;
    public List<float> buildingsPosX = new List<float>();
    public List<float> buildingsPosY = new List<float>();
    public List<string> Names = new List<string>();
    [SerializeField]
public GameObject testbuilding;
[SerializeField]
FX_Player gf;
[SerializeField]

Vector3 pos;
[SerializeField] Quaternion idk;
[SerializeField]
    Vector3 mi ;

    Transform mapt;
[SerializeField]
Vector3 maposset;
[SerializeField]
FX_MapGen mpp;

public Vector3[] tpos;
[SerializeField]
int curentcell;
[SerializeField]
Tilemap tilemap;
[SerializeField]
Vector3Int posi;
[SerializeField]
Tile df;
[SerializeField]
Sprite water;
    [SerializeField]
Sprite choptree;
[SerializeField]
    public Grid grid;
    [SerializeField]
    Tilemap myTileMap;
    [SerializeField]

    GameObject[] buildings;
    [SerializeField]

    glowmaster ri;
    [SerializeField]
    
    buildWheelOptions ti;
   
    public Sprite forest;
    public Sprite beach;
    public Sprite rockeyterrain;
    [SerializeField]
    cost placecost;
 public   bool justplaced;
  public  GameObject congratsforanvil;
    popdisp pod;
    // Start is called before the first frame update
    void Start()
    {
        mapt = mpp.Map;
        mapt.position = maposset;
        mapt.Rotate(-90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        justplaced = false;
        //child trans takes  the transforms of the buildings every frame
        childTrans = parrentForBuildings.GetComponentsInChildren<Transform>();
        childTransOrders = parrentForOrders.GetComponentsInChildren<Transform>();
        childScripts = parrentForBuildings.GetComponentsInChildren<destroy>();
        if (ti.orderWheelOn == false)
        {
            testbuilding = buildings[ti.curTier * 8 + ri.selectedring];
        }
        else if (ti.orderWheelOn == true)
        {
            testbuilding = buildings[24 + ri.selectedring];
        }
      
        pos = new Vector3(gf.TargetHex.position.x, gf.TargetHex.position.y, gf.TargetHex.position.z - 2f);
        posi.x = (int)pos.x;
        posi.y = (int)pos.y;
        posi.z = 45;
        //theproblemishere l98-101
        //Get position of the mouseclick
        mi = Input.mousePosition;
        mi.z = -73;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Convert position of the mouseclick to the position of the tile located at the mouseclick
        Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
        //Display tile position in log

        //Display the sprite value of the tile in log *SUCCESS*
        if (Input.GetKeyDown(KeyCode.Mouse0) && tpos.Contains(pos) == false && water != myTileMap.GetSprite(coordinate) && placecost.canafford == true && pauseMenuOn == false)
        {   //place bucket
            Debug.Log(myTileMap.GetSprite(coordinate));
            Debug.Log("test");
       if (
   
              ri.selectedring == 5 
               && ti.orderWheelOn == false
             )
         {
                Instantiate(testbuilding, pos, idk);
                //     Debug.Log(myTileMap.GetSprite(coordinate));
                //      checkForBuilding();
                //     if (canPlace == false)
                //     {
                //         canPlace = true;
                //         return;
                //     }
                //     tpos[curentcell] = pos;
                //    GameObject MyBuilding = Instantiate(testbuilding, pos, idk);
                //  MyBuilding.transform.position = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y - 0.10567f, -0.9500039f);
                //   MyBuilding.transform.parent = parrentForBuildings.transform;
                //    curentcell++;
               //  if (forest != myTileMap.GetSprite(grid.WorldToCell(MyBuilding.transform.position))) Destroy(MyBuilding); Debug.Log("destroyed the order");
            }
      //      Debug.Log(16 + ri.selectedring);
           //placeorder
            if ( forest == myTileMap.GetSprite(coordinate) && 16 + ri.selectedring == 18 && ti.orderWheelOn == true)
            {
                Debug.Log(myTileMap.GetSprite(coordinate));
                checkForBuilding();
                if (canPlace == false)
                {
                    canPlace = true;
                    return;
                }
                tpos[curentcell] = pos;
                GameObject MyBuilding =  Instantiate(testbuilding, pos, idk);
                MyBuilding.transform.position = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y - 0.10567f, -0.9500039f);
                MyBuilding.transform.parent = parrentForBuildings.transform;
                curentcell++;
                if (forest != myTileMap.GetSprite(grid.WorldToCell(MyBuilding.transform.position))) Destroy(MyBuilding); Debug.Log("destroyed the order");
            }
            else if (rockeyterrain == myTileMap.GetSprite(coordinate) && 16 + ri.selectedring == 17 && ti.orderWheelOn == true)
            {
                Debug.Log(myTileMap.GetSprite(coordinate));
                checkForBuilding();
                if (canPlace == false)
                {
                    canPlace = true;
                    return;
                }
                tpos[curentcell] = pos;
                GameObject MyBuilding =  Instantiate(testbuilding, pos, idk);
                MyBuilding.transform.position = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y - 0.10567f, MyBuilding.transform.position.z);
                MyBuilding.transform.parent = parrentForBuildings.transform;
                curentcell++;
                if (rockeyterrain != myTileMap.GetSprite(grid.WorldToCell(MyBuilding.transform.position))) Destroy(MyBuilding);Debug.Log("destroyed the order");
            }
         
            // place general
            else if (ti.orderWheelOn == false && ri.selectedring != 5)
            {
                // this checks if we can place and don't remove it because it it checking¨for loaded buildings
                checkForBuilding();
                if (canPlace == false)
                {
                    canPlace = true;
                    return;
                }
                GameObject MyBuilding = Instantiate(testbuilding, pos, idk);
                Debug.Log("L157");
                //this creates the building and set it to an object so it is a child
                MyBuilding.transform.position = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y - 0.10567f, MyBuilding.transform.position.z);
                MyBuilding.transform.parent = parrentForBuildings.transform;
                if (testbuilding.name == "anvil") MyBuilding.transform.localScale = new Vector3(2, 2, 1);
                ti.placedABuilding(testbuilding.name);
                curentcell++;
                tpos[curentcell] = pos;
            }
            //building properties
            if (testbuilding.name == "anvil")
            {
                congratsforanvil.SetActive(true);
            }
            if (testbuilding.name == "tent")
            {
                pod.maxpop += 3;
                pod.pop -= 3;
                PlayerPrefs.SetInt("pop", PlayerPrefs.GetInt("pop") -10  ); 
            }
            justplaced = true;
         
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            takeOutThePos();

            destroyBuilding();
            Debug.Log("L184");
        }
   
    }
    void checkForBuilding()
    {
        takeOutThePos();
        GameObject destroy = Instantiate(testbuilding, pos, idk);
        justplaced = true;
        Debug.Log("L191");
        destroy.transform.position = new Vector3(destroy.transform.position.x, destroy.transform.position.y - 0.10567f, destroy.transform.position.z);
        destroy.transform.parent = parrentForBuildings.transform;
        for (int i = 0; i < childScripts.Length; i++)
        {
            if (destroy.transform.position.x == buildingsPosX[i] && destroy.transform.position.y == buildingsPosY[i])
            {
                canPlace = false;
            }
        }
        Destroy(destroy, 0);
    }
    public void destroyAllBuildings()
    {
        curentcell = 0;
        for (int i = 0; i < tpos.Length; i++)
        {
            tpos[i] = new Vector3();
        }
        for (int i = 0; i < childScripts.Length; i++)
        {
            childScripts[i].destroyObjetct();
            if (i == childScripts.Length - 1)
            {
                return;
            }
        }

    }


    void destroyBuilding()
    {
        GameObject destroy = Instantiate(destroyBuildingPos, pos, idk);
        Debug.Log("L225");
        destroy.transform.position = new Vector3(destroy.transform.position.x, destroy.transform.position.y - 0.10567f, destroy.transform.position.z);
        destroy.transform.parent = parrentForBuildings.transform;
        for (int i = 0; i < childScripts.Length; i++)
        {
            if (destroy.transform.position.x == buildingsPosX[i] && destroy.transform.position.y == buildingsPosY[i])
            {
                childScripts[i].destroyObjetct();

            }
        }
        for (int i = 0; i < tpos.Length; i++)
        {
            if (tpos[i].x == pos.x && tpos[i].y == pos.y)
            {
                tpos[i] = new Vector3();
            }
        }
        Destroy(destroy, 0);
    }
    //changes the list for 1 sec
    public void takeOutThePos()
    {
        for (int i = 0;i < childTrans.Length - 1; i++)
        {
            buildingsPosX.Add(childTrans[i + 1].position.x);
            buildingsPosY.Add(childTrans[i + 1].position.y);
            Names.Add(childTrans[i + 1].name);
        }
        Invoke("resetTheList", 0.05f);
    }
    //resets the list
    void resetTheList()
    {
        buildingsPosX = new List<float>();
        buildingsPosY = new List<float>();
        Names = new List<string>();
    }
    //this create the buildings after loading note that you should have the fire bar selected in the game
    public void makeBuilding(float posX,float posY, string name)
    {
        curentcell--;
        childTrans = parrentForBuildings.GetComponentsInChildren<Transform>();
        if (name == "fire(Clone)")
        {
            GameObject MyBuilding = Instantiate(buildings[1], new Vector3(posX,posY , -0.9500039f), idk);
            MyBuilding.transform.parent = parrentForBuildings.transform;
            curentcell++;
            tpos[childTrans.Length - 1] = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y, -0.9500039f);
        }
        else if (name == "tent(Clone)")
        {
            GameObject MyBuilding = Instantiate(buildings[2], new Vector3(posX, posY , -0.9500039f), idk);
            MyBuilding.transform.parent = parrentForBuildings.transform;
            curentcell++;
            tpos[childTrans.Length - 1] = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y, -0.9500039f);
        }
        else if (name == "anvil(Clone)")
        {
            GameObject MyBuilding = Instantiate(buildings[4], new Vector3(posX, posY , -0.9500039f), idk);
            MyBuilding.transform.parent = parrentForBuildings.transform;
            MyBuilding.transform.localScale = new Vector3(2, 2, 1);
            curentcell++;
            tpos[childTrans.Length - 1] = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y, -0.9500039f);
        }
        else if (name == "farm(Clone)")
        {
            GameObject MyBuilding = Instantiate(buildings[3], new Vector3(posX, posY, -0.9500039f), idk);
            MyBuilding.transform.parent = parrentForBuildings.transform;
            MyBuilding.transform.localScale = new Vector3(2, 2, 1);
            curentcell++;
            tpos[childTrans.Length - 1] = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y, -0.9500039f);
        }
        else if (name == "dig(Clone)")
        {
            GameObject MyBuilding = Instantiate(buildings[25], new Vector3(posX, posY, -0.9500039f), idk);
            MyBuilding.transform.parent = parrentForBuildings.transform;
            MyBuilding.transform.localScale = new Vector3(2, 2, 1);
            curentcell++;
            tpos[childTrans.Length - 1] = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y, -0.9500039f);
        }
        else if (name == "tree_that_is_getting_chopped(Clone)")
        {
            GameObject MyBuilding = Instantiate(buildings[26], new Vector3(posX, posY, -0.9500039f), idk);
            MyBuilding.transform.parent = parrentForBuildings.transform;
            MyBuilding.transform.localScale = new Vector3(2, 2, 1);
            curentcell++;
            tpos[childTrans.Length - 1] = new Vector3(MyBuilding.transform.position.x, MyBuilding.transform.position.y, -0.9500039f);
        }
    }

}