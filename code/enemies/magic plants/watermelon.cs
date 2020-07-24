using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class watermelon : MonoBehaviour
{


    public GameObject[]targets;



    //statts
    public float speed;

    public int growthstate2startingpoint;

    public int growthstate3startingpoint;

    public int currentgrowthstate;

    public float currentgrowth;
    public int t;
    public int rand;
    public float growth_coeficient;
    public Transform tr;

    bool oncce;

    //reaction

    public GameObject target_plant;
    // Start is called before the first frame update
    void Start()
    {
        currentgrowth = growth_coeficient;
        tr = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targets = GameObject.FindGameObjectsWithTag("attackable-plant");
        if (currentgrowth < growthstate3startingpoint)
        {
            currentgrowth++;
        }

        if (currentgrowth > growthstate2startingpoint && currentgrowth < growthstate3startingpoint)
        {
            currentgrowthstate = 2;
        }
        if (currentgrowth > growthstate3startingpoint-1)
        {
            currentgrowthstate = 3;

        }

        // change size 
        tr.localScale = new Vector3(currentgrowth / growth_coeficient, currentgrowth / growth_coeficient, currentgrowth / growth_coeficient);

        //reaction
        if (currentgrowthstate == 3)
        {
            //  if (t > 600)
            //  {
         if   (oncce == true)
            {
                rand = Random.Range(2, targets.Length);
                oncce = false;
            }
             
              //  if(targets[rand] = this.gameObject)
             //   {
              //      Destroy(this.gameObject);
             //   }
                target_plant = targets[rand];

       //     }
         //   target_plant = GameObject.FindWithTag("attackable-plant");
                t = 0;
            
          
            t++;
            if (target_plant == null || target_plant == this.gameObject)
            {
                rand = Random.Range(2, targets.Length);
                target_plant = targets[rand];
            }
                if (target_plant != null && target_plant != this.gameObject)
            {
                transform.position = Vector3.MoveTowards(tr.position, target_plant.transform.position, speed);
            }

        }
          
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.gameObject == target_plant)
        {
            Debug.Log("collision with target");
            Destroy(target_plant);
            Destroy(this.gameObject);
        }
    }
}

