using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hapiness : MonoBehaviour
{
    public Sprite happy;
    public Sprite content;
    public Sprite angry;
    public Sprite neardeath;
  public  int happyness = 70;
    Transform par;
    // Update is called once per frame
    void Update()
    {
        if (happyness > 70)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = happy;
        }
        if (happyness < 70)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = content;
        }
        if (happyness < 50)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = angry;
        }
        if (happyness < 30)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = neardeath;
        }
      
    }
}
