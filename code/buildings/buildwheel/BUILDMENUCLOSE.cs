using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BUILDMENUCLOSE : MonoBehaviour
{
    public bool state = false;
    public bool test;
    [SerializeField]
    GameObject buildwheel;
    [SerializeField]
    Animation buildingwheel;
  
  
    [SerializeField]
    int delay;
    void Update()
    {
        
        delay++;
        if (Input.GetKeyDown(KeyCode.B))
        {
      
        if (delay > 200)
        {
            if (state == true)
            {

      
                buildingwheel.Play("closebuildcircle");

                state = false;
                delay = 0;
            }
        }
        if ( delay > 200)
        {
            if (state == false)
            {

              
                buildingwheel.Play("openbuildcircle");

                state = true;
                delay = 0;
            }
        }






           

       }







    }

}

