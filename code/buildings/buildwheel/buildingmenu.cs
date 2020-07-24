using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class buildingmenu : MonoBehaviour
{
    public glowmaster Glowmaster;
    [SerializeField]
    private int mynumber;
    [SerializeField]
    Animation glow;
    void Update()
    {
      if (mynumber == Glowmaster.selectedring)
        {
            glow.Play("select");
        }














    }
    
}
