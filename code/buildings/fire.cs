using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
 public   fooddipslay fd;
  public  int ft ;
    public int it;
    public   int fooddelay;
  public  irondisplay ir;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
     

            ft++;
            if (fd.unfood > 0 && ft > fooddelay)
            {
                fd.food += 2;
                fd.unfood -= 1;
                ft = 0;
            }

        it++;
            if (ir.unrefinediron > 0 && it > 1000)
            {
                ir.unrefinediron -= 2;

                ir.iron+=1;
                it = 0;
            }
            
        }  
    }

