using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun_disble : MonoBehaviour
{

    public Transform player ;
    public Light light_obj;
    public float sunmax;
    public float light_weakening;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (player.transform.position.y <sunmax){
            light_obj.intensity  = player.transform.position.y +light_weakening;
        }
          //if  (player.transform.position.y >sunmax){
       //     light_obj.enabled = true;
       // }
    }
}
