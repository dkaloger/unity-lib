using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farm : MonoBehaviour
{
   public  fooddipslay fod;
  int T;
    // Update is called once per frame
    void Update()
    {
        T++;
            if (T > 1000)
        {
            fod.unfood += 2;
            T = 0;
        }
    }
}
