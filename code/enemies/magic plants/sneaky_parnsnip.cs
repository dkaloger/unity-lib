using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sneaky_parnsnip : MonoBehaviour
{
  public  float speed;
    public Vector3 wander;

    //statts

    // public int growthstate1startingpoint;
    public int growthstate2startingpoint;

    public int growthstate3startingpoint;

    public int currentgrowthstate;

    public float currentgrowth;

    public float growth_coeficient;
    public Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        wander = new Vector3(Random.Range(15, 97), -2.33f, Random.Range(18, 100));
        currentgrowth = growth_coeficient;
        tr = gameObject.GetComponent<Transform>();
    }
   

    // Start is called before the first frame update
   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentgrowth < growthstate3startingpoint)
        {
            currentgrowth++;
        }

        if (currentgrowth > growthstate2startingpoint && currentgrowth < growthstate3startingpoint)
        {
            currentgrowthstate = 2;
        }
        if (currentgrowth +1 > growthstate3startingpoint)
        {
            currentgrowthstate = 3;
        }

        // change size 
        tr.localScale = new Vector3(currentgrowth / growth_coeficient, currentgrowth / growth_coeficient, currentgrowth / growth_coeficient);
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(transform.position.x, wander.x))
            {
            wander = new Vector3(Random.Range(15, 97), -2.33f, Random.Range(18, 100));
        }
        if (currentgrowthstate == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, wander, speed);
        }

      
    }
}
