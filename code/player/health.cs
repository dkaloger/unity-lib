using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int HP_now;
    public int HP_Max;
    public bool isplayer;
    public bool stunned= false;
    public int t;
    public int stun_time;
    // Start is called before the first frame update
    void Start()
    {
        HP_now = HP_Max;
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned == true)
        {
            t++;
        }
        if (t > stun_time)
        {
            stunned = false;
            HP_now = 100;
               t = 0;
        }
        if (isplayer== true&& HP_now < 1)
        {
            stunned = true;
        }
    }
}
