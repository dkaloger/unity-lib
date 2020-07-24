using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binocular : MonoBehaviour
{
    public movement Q;
    public bool binocular_enabled;
    public Camera player;
    public Transform player_tr;
    public float binocular_clamp_min;
    public float binocular_clamp_max;
    public float FOV;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            binocular_enabled = !binocular_enabled;
            Q.Qtoggle = false;
        }


   

        if (binocular_enabled == false)
        {

            FOV = binocular_clamp_max;


        }


            if (binocular_enabled == true)
        {
            FOV= PlayerPrefs.GetFloat("fov");
            FOV -= Input.mouseScrollDelta.y;
            FOV = Mathf.Clamp(FOV, binocular_clamp_min, binocular_clamp_max);

            PlayerPrefs.SetFloat("fov", FOV);

        }

        b.SetActive(binocular_enabled);
        player.fieldOfView = FOV;






    }
}
