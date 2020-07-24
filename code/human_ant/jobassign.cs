using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class jobassign : MonoBehaviour
{
   public popdisp pop;
   public int miningjobs;
    public int lumberjobs;
    public int test;
    public int num1;
    public int num2;
    public int relativeminingjobs;
    public int relativelumberjobs;
    // Start is called before the first frame update
    void Start()
    {
        //find ratio 
        miningjobs = PlayerPrefs.GetInt("chop");
        lumberjobs = PlayerPrefs.GetInt("mine");
        num1 = 100 / pop.pop;
        relativeminingjobs = miningjobs / num1;
        num2 = 100 / pop.pop;
        relativelumberjobs = lumberjobs / num2;

    }

    // Update is called once per frame
    void Update()
    {
        test = pop.pop;
         if(relativeminingjobs != miningjobs / num1)
        {
            relativeminingjobs++;
        }
        if (relativelumberjobs != lumberjobs / num2)
        {
            relativelumberjobs++;
        }

    }
}
