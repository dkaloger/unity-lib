using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class dkalogertest : MonoBehaviour
{
    [SerializeField]
    GameObject testBuilding;
    int Delay;
    Quaternion tge;
    public Vector3 pointr;

    [SerializeField]
    float Mycolumn;
    [SerializeField]
bool trigeredl;
    [SerializeField]
bool curentlyplacingregular;
[SerializeField]
   
   public Vector3 correction;
   public 
    void Update() {

       
        Mycolumn = Mathf.Floor(pointr.x) ;
if(pointr.x - (Mathf.Floor(pointr.x))>0.4f&&pointr.x - (Mathf.Floor(pointr.x)) > 0.4f)
        Delay++;
        if (Mycolumn % 2 == 1)
        {
            curentlyplacingregular = true;
            trigeredl=true;
        }
        else if (Mycolumn % 2 == 0)
        {
            curentlyplacingregular = false;
            trigeredl = true;
        }
        

        pointr = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)){


            if (curentlyplacingregular == true && trigeredl == true && pointr.x - (Mathf.Floor(pointr.x)) > 0.35f )
            {
                pointr += correction;


            }
              


          if (curentlyplacingregular == true && trigeredl == true)
            {

            pointr.x = (Mathf.Floor(pointr.x));
              pointr.y = (Mathf.Floor(pointr.y));
               pointr.z = -10;
              
          
                Instantiate(testBuilding, pointr, tge);
                trigeredl = false;

            }

            if (curentlyplacingregular == false && trigeredl == true)
            {

                pointr.x = (Mathf.Floor(pointr.x));
                pointr.y = (Mathf.Floor(pointr.y))+0.5f;
                pointr.z = -10;
               
                Instantiate(testBuilding, pointr, tge);
                trigeredl = false;
                pointr.y -= 0.5f;

            }

           
            Delay = 0;
            
        }

    }
 
} 
               
    

