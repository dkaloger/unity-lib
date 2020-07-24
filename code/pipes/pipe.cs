using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
  //  public GameObject Entry;
 // public  GameObject Exit;
    public int interuptions;
    public int solved;
    public bool flowing;
  //  int i;
    // Start is called before the first frame update
        void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (solved >= interuptions)
        {
            flowing = true;
        }
    }
}
