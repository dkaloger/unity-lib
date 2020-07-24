using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public Light light1;
    public Transform transform_player;
    public float offset;
    public float lightweakening;
    public Material material_ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  light1.range = lightweakening * transform_player.position.y + offset;
//        print(transform_player.position.y);
      if(transform_player.position.y > -1f)
       {
            material_ground.SetFloat("_Metallic", 0.241f);
 }
    if (transform_player.position.y < -1f)
  {
material_ground.SetFloat("_Metallic", lightweakening * transform_player.position.y + offset);
      }
    }
}
