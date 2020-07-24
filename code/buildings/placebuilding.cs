using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class placebuilding : MonoBehaviour
{
    [SerializeField]
    glowmaster glowmaster1;
    [SerializeField]
    buildWheelOptions buildWheelOptions1;
    public float gridSizeY = 1f;
    public float gridSizeX = 0.75f;
    private Vector3 snapPos;
    Vector3 MyBuildPos;
    bool isInList2 = false;
    float var = 1.25f;
    List<float> buildingPosXTest = new List<float>();
    bool Bool = false;
    int testInt = 0;

    public GameObject gridObj;
    public Transform tileMapPos;
    List<Vector3Int> objPos = new List<Vector3Int>();
    public Vector3 pointr;
    public GameObject testBuilding;
    public bool orderWheelOnP = false;
    private int tiers = 0;
    public Tilemap buildings;
    Vector3Int clickedpos;
    public Tile[] Buldings;
    public GameObject techTree;
    [SerializeField]
    Canvas myCanvas;
    Vector2 pos;
    public Transform tra;
    public Camera maincam;
    public Vector3 correction;
    public GameObject[] objbuildings;
    //  void Update()
    //   {
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
    //        clickedpos.x = (int)Mathf.Round(myCanvas.transform.TransformPoint(pos).y) + (int) Mathf.Round(correction.x);
    //     clickedpos.y = (int)Mathf.Round(myCanvas.transform.TransformPoint(pos).x)+(int)Mathf.Round(correction.y) ;
    //    clickedpos.z = (int)myCanvas.transform.TransformPoint(pos).z;
    //   if (Input.GetKeyDown(KeyCode.Space) && maincam.GetComponent<Camera>().orthographicSize < 3.735543)
    //    {
    //       buildings.SetTile(clickedpos, Buldings[buildingWheel.GetComponent<glowmaster>().selectedring]);
    //      Debug.Log(clickedpos);

    //     }

    // }
    [SerializeField]
    Tilemap tilemp;

    void Update()
    {
        
        testBuilding =null;
        //Debug.Log(buildWheelOptions1.curTier * 8 + glowmaster1.selectedring);

        pointr = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        double carPosX = tileMapPos.transform.position.x;
        double carPosX2 = (int)carPosX;

        //float p3 = p - p2;
        double carPosX3 = carPosX - 107f;

         //Single f = tileMapPos.transform.position.x - (int)tileMapPos.transform.position.x;

        float f = tileMapPos.position.x;

        float f2 = f - (int)f;

        Debug.Log(f2);

        /*
        Debug.Log(Double.Parse(f.ToString()) - (int)f);

        double d2 = Double.Parse(f.ToString());

        double d3 = d2 - (int)d2;



        Debug.Log(d3);
        */

        //Debug.Log(buildingPosXTest[0]);
        //Debug.Log("isInList2");

        //float test = 51f;
        //Debug.Log(test % 2);
        //float double_value = -30.555F;
        //Debug.Log((int)((double_value - (int)double_value) * 100) + "this is a test");
        //float decimalPart = 22.45F;
        //decimalPart.ToString("F0" + "this should show 22");-
        //Debug.Log(Mathf.Round(decimalPart));
        //point.x = (int)Camera.main.ScreenToWorldPoint(Input.mousePosition.x);
        pointr = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //point = (int)Input.mousePosition.y;

        if (Input.GetMouseButtonDown(0) && orderWheelOnP == false)
        {
            //if ((int)point.y % 1 == 0.5F && (int)point.x % 1 == 0.25F || (int)point.x % 1 == 0.75F)
            var myBuilding = Instantiate(testBuilding, new Vector3(pointr.x, pointr.y, 1), Quaternion.identity);
            //myBuilding.transform.parent = gridObj.transform;
            float myCheckPosY = myBuilding.transform.position.y;
            float myCheckPosY2 = Mathf.Floor(myCheckPosY);
            myCheckPosY = myCheckPosY - myCheckPosY2;
            float myCheckPosX = myBuilding.transform.position.x;
            float myCheckPosX2 = Mathf.Floor(myCheckPosX);
            myCheckPosX = myCheckPosX - myCheckPosX2;
            float xUnEven = myCheckPosX % 2;
            float comTest1 = 22.55f;
            float comTest2 = 22.66f;
            float test2 = 1.5f;
            float test = 0;
            Debug.Log(comTest2.CompareTo(comTest1) + " com thing");//this returns -1 or 1,  1 if is the first is greater than the other the other is the oppersit
                                                                       //Debug.Log(myCheckPosX);

            techTree.GetComponent<techTree>().addBuilding(GetComponent<glowmaster>().selectedring - 1);
            float nowGrid = 1f / gridSizeX;
            float nowGridY = 1f / gridSizeY;
            if (myCheckPosY >= 0.5)
            {

                    //Debug.Log("you made it to y1");
                if (myCheckPosX >= 0.5)
                {
                    Vector3 MyBuildPos;
                    MyBuildPos.x = Mathf.Round(myBuilding.transform.position.x * nowGrid) / nowGrid;
                    MyBuildPos.y = Mathf.Round(myBuilding.transform.position.y * nowGridY) / nowGridY;
                    MyBuildPos.z = 1;
                    myBuilding.transform.position = MyBuildPos;
                    myCheckPosX2 = Mathf.Floor(myCheckPosX);
                    myCheckPosX = myCheckPosX - myCheckPosX2;
                    if (myCheckPosX == 0.5)
                    {
                        myBuilding.SetActive(false);
                    }
                    else if (myCheckPosX == 0)
                     {
                            myBuilding.SetActive(false);
                        }
                    }
                    else if (myCheckPosX < 0.5)
                    {
                        Vector3 MyBuildPos;
                        MyBuildPos.x = Mathf.Round(myBuilding.transform.position.x * nowGrid) / nowGrid;
                        MyBuildPos.y = Mathf.Round(myBuilding.transform.position.y * nowGridY) / nowGridY;
                        MyBuildPos.z = 1;
                        myBuilding.transform.position = MyBuildPos;
                        myCheckPosX2 = Mathf.Floor(myCheckPosX);
                        myCheckPosX = myCheckPosX - myCheckPosX2;
                        if (myCheckPosX == 0.5)
                        {
                            myBuilding.SetActive(false);
                        }
                        else if (myCheckPosX == 0)
                        {
                            myBuilding.SetActive(false);
                        }
                    }
                }//y case 1
                else if (myCheckPosY < 0.5)
                {
                    //Debug.Log("you made it to y2");
                    if (myCheckPosX < 0.5)
                    {
                        //Debug.Log("you made it to y2 x1");
                        MyBuildPos.x = Mathf.Round(myBuilding.transform.position.x * nowGrid) / nowGrid;
                        MyBuildPos.y = Mathf.Round(myBuilding.transform.position.y * nowGridY) / nowGridY;
                        MyBuildPos.z = 1;
                        myBuilding.transform.position = MyBuildPos;
                        myCheckPosX = myBuilding.transform.position.x;
                        myCheckPosX2 = Mathf.Floor(myCheckPosX);
                        myCheckPosX = myCheckPosX - myCheckPosX2;
                        if (myCheckPosX == 0.25)
                        {
                            myBuilding.SetActive(false);
                        }
                        else if (myCheckPosX == 0.75)
                        {
                            myBuilding.SetActive(false);
                        }
                    }
                    else if (myCheckPosX >= 0.5)
                    {
                        //Debug.Log("you made it to y2 x2");
                        Vector3 MyBuildPos;
                        MyBuildPos.x = Mathf.Round(myBuilding.transform.position.x * nowGrid) / nowGrid;
                        MyBuildPos.y = Mathf.Round(myBuilding.transform.position.y * nowGridY) / nowGridY;
                        MyBuildPos.z = 1;
                        myBuilding.transform.position = MyBuildPos;
                        myCheckPosX2 = Mathf.Floor(myCheckPosX);
                        myCheckPosX = myCheckPosX - myCheckPosX2;
                        if (myCheckPosX == 0.25)
                        {
                            myBuilding.SetActive(false);
                        }
                        else if (myCheckPosX == 0.75)
                        {
                            myBuilding.SetActive(false);
                        }

                    }
                }//y case 2

                //float test = myBuilding.trsform.position.y - myBuilding.transform.position.y * 100;
                //Debug.Log(myCheckPosY + " this should remove the hole numbers");
                //Debug.Log(System.Math.Truncate(22.99999999m));
                //if (myBuilding.transform.position.y - myBuilding.transform.position.y * 1000 == 50)
            }

        }

        //Vector3Int selectedTile = tilemp.WorldToCell(point);
        ////tilemp.SetTile(selectedTile, Buldings[GetComponent<glowmaster>().selectedring -1 + tiers]);
        //var myBuilding = Instantiate(testBuilding, new Vector3((int)point.x, (int)point.y, 1), Quaternion.identity);
        //myBuilding.transform.parent = gridObj.transform;
        //float decimalPart = 99.55F % 1F;
        //Debug.Log(decimalPart +"this is the line i found on internet");
        // float double_value = 0.5F;
        //Debug.Log((int)((double_value - (int)double_value) * 100));
        //Debug.Log((int)point.x + "x" + (int)point.y + "y" + (int)point.z + "z");
        //Debug.Log(System.Math.Ceiling(System.Math.Log10(22.55F)) + "this should show 2");
        //Debug.Log(decimalPart.ToString("F0" + "this should show 22"));
        //techTree.GetComponent<techTree>().addBuilding(GetComponent<glowmaster>().selectedring - 1);

    public void tierChange(int tier)
    {
        tiers = tier * 8;
    }
}
