using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playerinteractions : MonoBehaviour
{
    public adiomanager_main au;
    //market
    public int my_money;
  //  public TextMeshProUGUI t;
  //  public TextMeshPro tmp;

    public int watermelonprice;

    public int parsnipprice;
    public int cornprice;
    //  public int watermelonprice;
    //public plant_player col;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        //planting



    }
    void OnCollisionEnter(Collision collision)
    {
        //planting

        //harvesting
        if (collision.gameObject.tag == "plant" || collision.gameObject.tag == "attackable-plant") {
            Debug.Log("l28");
            /*col = collision.gameObject.GetComponent<plant_player>();
            if (col.currentgrowthstate_loc == 2f || col.currentgrowthstate_loc == 3f)
            {
                au.Play();


                Destroy(collision.gameObject);
               // }
              
            }*/
        }
    }
}
