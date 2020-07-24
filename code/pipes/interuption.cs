using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interuption : MonoBehaviour
{
 public   bool solved;
    public pipe pipec;
    Collider my_collider;
    // Start is called before the first frame update
    void Start()
    {
        my_collider = gameObject.GetComponent<Collider>();
        pipec.interuptions ++;
    }
  private void OnTriggerEnter(Collider other)
    {
        if(solved == false)
        {
            solved = true;
            pipec.solved++;
            my_collider.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
