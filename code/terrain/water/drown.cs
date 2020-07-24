using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class drown : MonoBehaviour
{
   public mission1 mission1;
  public    bool isenemy;
      public  water water;
    public int t;
    public int drown_time;
  public  bool isdrowning;
  public float adjustment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(water.absoluteheight- adjustment < gameObject.transform.position.y){
           t=0;   
        isdrowning = false; 
           }

        if(water.absoluteheight - adjustment > gameObject.transform.position.y){
          print("fdd");
t++;
isdrowning = true;
if (t > drown_time && isenemy == false){

 SceneManager.LoadScene("missionfailed");
}
if (t > drown_time && isenemy == true){
       mission1.killed_enemies ++;
Destroy(gameObject);
}


        }
        
     
    }
}
