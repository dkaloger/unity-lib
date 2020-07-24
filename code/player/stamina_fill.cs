using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stamina_fill : MonoBehaviour
{
    public playercontroller p;
    public ground g;
    public Image c;
    public float staminaregain;

    public float fill;
    public float staminadepletion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    //    c.fillAmount = 1 - g.globalmoves / staminadepletion;
     //   c.fillAmount += staminaregain / staminadepletion;
     c.fillAmount =  fill;
        fill = 1 - (g.globalmoves / staminadepletion);
        fill += staminaregain / staminadepletion;
        if (fill == 0)
        {
            p.cutenabled = false;
        }
        if (fill > 1)
        {
            fill = 1;
        }
    }
}
