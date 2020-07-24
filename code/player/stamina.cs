using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamina : MonoBehaviour {
    public movement movement;
public float stamina_now;
    public float stamina_regen;
    public bool stamina_ok = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(stamina_now < 0.1f)
        {
            stamina_ok = false;
        }
        if (stamina_now > 0.9f)
        {
            stamina_ok = true;
        }
        if (movement.isGrounded)
        {
            stamina_now += stamina_regen;
        }
        stamina_now = Mathf.Clamp01(stamina_now);
    }
}
