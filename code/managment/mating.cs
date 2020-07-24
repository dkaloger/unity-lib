using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mating : MonoBehaviour
{
    [SerializeField]
    Slider m;
    public int matingspeedint;
    bool changening;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        changening = false;
    }
    public void df()
    {
        changening = true;
    }
    private void Update()
    {
        if(changening == false)
        {
            m.value = PlayerPrefs.GetInt("matingspeed");
        }
        PlayerPrefs.SetInt("matingspeed",(int) m.value);
        matingspeedint = PlayerPrefs.GetInt("matingspeed");

    }
    

    

}