using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
  public  fooddipslay fd;
    public GameObject gt;
   public hapiness hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponentInChildren <hapiness>();
        gt = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hp.happyness < 20)
        {
            Debug.Log("l22");
            fd.food += 100;
            Destroy(gt);
        }
    }
}
