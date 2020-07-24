using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_seeds : MonoBehaviour
{
 public   GameObject seeds;
    public int storedseeds =0;
    public Transform spawnlocation;
    public int delay;
  public  int t;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        t++;
    }
    // Update is called once per frame
    void Update()
    {
        if(storedseeds == 0 &&t > delay)
        {
            Instantiate(seeds, spawnlocation);
            storedseeds++;
            t = 0;
        }
     
    }
}
