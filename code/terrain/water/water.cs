using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class water : MonoBehaviour
{
  
public float t;
public BoxCollider triger;
public pipe pipe;
public int hitbox;
public float collidersize ;
public float flowspeed;
public float collider_Position;
 public float absoluteheight;
    void Update()
    {
        if(gameObject.GetComponent<Image>().fillAmount != 1){
absoluteheight  = -11 + gameObject.GetComponent<Image>().fillAmount *collidersize ;
        if(pipe.flowing == true){
  t += 0.1f;
 // collidersize = t/ hitbox;
  gameObject.GetComponent<Image>().fillAmount = t/ flowspeed;
        }

  //    triger.size = new Vector3(triger.size.x, collidersize/2,triger.size.z);
  //   triger.center = new Vector3(triger.center.x,(t/collider_Position) -(t/collider_Position)*2,triger.center.z);
       
        }
        
    }
}
