using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class show_health : MonoBehaviour
{
    public health health;
    public Image im;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        im.fillAmount = health.HP_now/100f;
    }
}
