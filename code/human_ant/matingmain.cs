using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matingmain : MonoBehaviour
{
    [SerializeField]
    fooddipslay foodD;
    [SerializeField]
    popdisp popdispv;
  public  int popdelay;

    [SerializeField]
    public  int standartgrowthspeed;
    [SerializeField]
    public  int popfoodcostonce;
    [SerializeField]
    GameObject human;
    [SerializeField]
    Transform human1;
    [SerializeField]
    popdisp pod;
    [SerializeField]
    Vector3 v;
    Quaternion r;
    // Start is called before the first frame update

    void FixedUpdate()
    {
        Debug.Log("l21m");
   
        if (popdelay < 4)
        {
            popdelay += PlayerPrefs.GetInt("matingspeed") * 2 * pod.pop / 10;
        }
        if (popdelay > 4)
        {
            popdelay += PlayerPrefs.GetInt("matingspeed") * pod.pop / 10;
        }
    }
    // Update is called once per frame
    void Update()
    {

        Debug.Log("l28m");
      
        if (popdelay>standartgrowthspeed && pod.maxpop > pod.pop )
        {
            popdelay = 0;
            popdispv.pop++;
            foodD.food -= popfoodcostonce;
            Instantiate(human,human1);
        }
    }
}
