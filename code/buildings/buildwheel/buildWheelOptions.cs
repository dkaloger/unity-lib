using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildWheelOptions : MonoBehaviour
{
    int unCooked = 100;
    int cooked = 0;
    public GameObject resoueceSystem;
    public Animation animations;
    public int curTier = 0;
    public List<int> tiersUnlocked = new List<int>();
    // [SerializeField]
    // placeBuildingObj PlaceBuildingObj;

    [SerializeField] Sprite[] mySprites = new Sprite[8];
    [SerializeField] GameObject[] myBuildings = new GameObject[8];

    public bool orderWheelOn;
    private void Start()
    {
        tiersUnlocked.Add(0);
        myBuildings[0].GetComponent<SpriteRenderer>().sprite = mySprites[0];
        myBuildings[1].GetComponent<SpriteRenderer>().sprite = mySprites[1];
        myBuildings[2].GetComponent<SpriteRenderer>().sprite = mySprites[2];
        myBuildings[3].GetComponent<SpriteRenderer>().sprite = mySprites[3];
        myBuildings[4].GetComponent<SpriteRenderer>().sprite = mySprites[4];
        myBuildings[5].GetComponent<SpriteRenderer>().sprite = mySprites[5];
        myBuildings[6].GetComponent<SpriteRenderer>().sprite = mySprites[6];
        myBuildings[7].GetComponent<SpriteRenderer>().sprite = mySprites[7];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (curTier != 0 && orderWheelOn == false)
            {
                curTier = tiersUnlocked[curTier - 1];
                //PlaceBuildingObj.tierChange(curTier);
                animations.Play("changeTier");
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (curTier != tiersUnlocked.Count -1 && orderWheelOn == false)
            {
                curTier = tiersUnlocked[curTier +1];
                // PlaceBuildingObj.tierChange(curTier);
                animations.Play("changeTier");
            }

        }
        if (Input.GetKeyDown(KeyCode.O))  {
            animations.Play("orderWheel");
        }
    }

    public void changeImage(int tier)
    {
        if (tier == 0)
        {
            myBuildings[0].GetComponent<SpriteRenderer>().sprite = mySprites[0];
            myBuildings[1].GetComponent<SpriteRenderer>().sprite = mySprites[1];
            myBuildings[2].GetComponent<SpriteRenderer>().sprite = mySprites[2];
            myBuildings[3].GetComponent<SpriteRenderer>().sprite = mySprites[3];
            myBuildings[4].GetComponent<SpriteRenderer>().sprite = mySprites[4];
            myBuildings[5].GetComponent<SpriteRenderer>().sprite = mySprites[5];
            myBuildings[6].GetComponent<SpriteRenderer>().sprite = mySprites[6];
            myBuildings[7].GetComponent<SpriteRenderer>().sprite = mySprites[7];
        }
        else if (tier == 1)
        {
            myBuildings[1].GetComponent<SpriteRenderer>().sprite = mySprites[9];
            myBuildings[2].GetComponent<SpriteRenderer>().sprite = mySprites[10];
            myBuildings[3].GetComponent<SpriteRenderer>().sprite = mySprites[11];
            myBuildings[4].GetComponent<SpriteRenderer>().sprite = mySprites[12];
            myBuildings[5].GetComponent<SpriteRenderer>().sprite = mySprites[13];
            myBuildings[6].GetComponent<SpriteRenderer>().sprite = mySprites[14];
            myBuildings[7].GetComponent<SpriteRenderer>().sprite = mySprites[15];
        }
        else if (tier == 2)
        {
            myBuildings[0].GetComponent<SpriteRenderer>().sprite = mySprites[0];
            myBuildings[3].GetComponent<SpriteRenderer>().sprite = mySprites[16];
            myBuildings[7].GetComponent<SpriteRenderer>().sprite = mySprites[17];
            myBuildings[6].GetComponent<SpriteRenderer>().sprite = mySprites[18];
            myBuildings[1].GetComponent<SpriteRenderer>().sprite = mySprites[3];
            myBuildings[2].GetComponent<SpriteRenderer>().sprite = mySprites[3];
            myBuildings[4].GetComponent<SpriteRenderer>().sprite = mySprites[3];
            myBuildings[5].GetComponent<SpriteRenderer>().sprite = mySprites[3];
        }

    }
 
    public void aniChange()
    {
        changeImage(curTier);
    }
    public void orderChange()
    {
        if (orderWheelOn == true)
        {
            //  PlaceBuildingObj.orderWheelOnP = false;
            changeImage(curTier);
            orderWheelOn = false;
        }
        else if (orderWheelOn == false)
        {
        //    PlaceBuildingObj.orderWheelOnP = true;
            orderWheelOn = true;
            myBuildings[1].GetComponent<SpriteRenderer>().sprite = mySprites[19];
            myBuildings[2].GetComponent<SpriteRenderer>().sprite = mySprites[19];
            myBuildings[3].GetComponent<SpriteRenderer>().sprite = mySprites[19];
            myBuildings[4].GetComponent<SpriteRenderer>().sprite = mySprites[19];
            myBuildings[5].GetComponent<SpriteRenderer>().sprite = mySprites[20];
            myBuildings[6].GetComponent<SpriteRenderer>().sprite = mySprites[21];
            myBuildings[7].GetComponent<SpriteRenderer>().sprite = mySprites[22];
        }
    }

    public void addTier(int tier)
    {
        tiersUnlocked.Add(tier);
    }
    public void placedABuilding(string name)
    {
        if (name == "tent")
        {
            popdisp[] PopDisp = resoueceSystem.GetComponentsInChildren<popdisp>();
            PopDisp[0].maxpop += 3;
        }
        else if (name == "fire")
        {
            fooddipslay[] FoodDisplay = resoueceSystem.GetComponentsInChildren<fooddipslay>();
            cooked = (unCooked * 2) + cooked;
            unCooked = 0;
            FoodDisplay[0].food = FoodDisplay[0].food;
        }
        else if (name == "anvil" && tiersUnlocked.Count == 1 || tiersUnlocked.Count == 2)
        {
            tiersUnlocked.Add(tiersUnlocked.Count);
        }
    }

}
