using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class collectr : MonoBehaviour
{
[SerializeField]
    int myjob;
    // 1 lumber
    // 2 mining
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject target;
[SerializeField]
    jobassign jobassin;
    [SerializeField]
    wooddisplay woody;
    [SerializeField]
    stonedisplay stony;
    [SerializeField]
    irondisplay irony;
    [SerializeField]
    int t;
    int ironluck;
    void OnTriggerStay(Collider other)
    {
        if (myjob == 1)
        {

            t++;

            if (t > 500)
            {
                woody.wood++;
                t = 0;

            }
        }

        if (myjob == 2)
        {

            t++;

            if (t > 500)
            {
                stony.stone++;
                t = 0;
                ironluck++;
                if (ironluck > 9)
                {
                    irony.unrefinediron++;
                    ironluck= 0;
                }
            }
        }
    }
   
     

    

    // Update is called once per frame
    void Update()
    {
        if (jobassin.relativelumberjobs > 0 && myjob == 0)
        {
            myjob = 1;
            jobassin.relativelumberjobs -= 1;
            PlayerPrefs.SetInt("chop", PlayerPrefs.GetInt("chop") - 1);
        }
        else if (jobassin.relativeminingjobs > 0&& myjob == 0)
        {
            myjob = 2;
            jobassin.relativeminingjobs -= 1;
            PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") - 1);
        }
        if (myjob == 1)
        {
            target = GameObject.FindGameObjectWithTag("chop");
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);


        }
        if (myjob == 2)
        {
            target = GameObject.FindGameObjectWithTag("diggy");
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);


        }

    }
   
}

