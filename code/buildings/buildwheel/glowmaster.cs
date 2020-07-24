using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowmaster : MonoBehaviour
{
    public int selectedring;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedring++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedring -= 1;
        }
        if(selectedring == 9)
        {
            selectedring = 1;
        }
        if (selectedring == 0)
        {
            selectedring = 8;
        }
    }
}
