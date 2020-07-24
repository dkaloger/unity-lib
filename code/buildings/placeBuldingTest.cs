using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class placeBuldingTest : MonoBehaviour
{

  public  GameObject testBuilding;
    int Delay;
    Quaternion tge;
    public Vector3 point;

    [SerializeField]
    float Mycolumn;
    [SerializeField]
    bool trigeredl;
    [SerializeField]
    bool curentlyplacingregular;
    [SerializeField]

    void Update()
    {


        Mycolumn = Mathf.Floor(point.x);
        if (point.x - (Mathf.Floor(point.x)) > 0.4f && point.x - (Mathf.Floor(point.x)) > 0.4f)
            Delay++;
        if (Mycolumn % 2 == 1)
        {
            curentlyplacingregular = true;
            trigeredl = true;
        }
        else if (Mycolumn % 2 == 0)
        {
            curentlyplacingregular = false;
            trigeredl = true;
        }

        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {






            if (curentlyplacingregular == true && trigeredl == true)
            {

                point.x = (Mathf.Floor(point.x));
                point.y = (Mathf.Floor(point.y));
                point.z = -10;
                Instantiate(testBuilding, point, tge);
                trigeredl = false;

            }

            if (curentlyplacingregular == false && trigeredl == true)
            {

                point.x = (Mathf.Floor(point.x));
                point.y = (Mathf.Floor(point.y)) + 0.5f;
                point.z = -10;

                Instantiate(testBuilding, point, tge);
                trigeredl = false;
                point.y -= 0.5f;

            }


            Delay = 0;

        }

    }

}
