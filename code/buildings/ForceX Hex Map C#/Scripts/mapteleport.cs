using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapteleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(102.26f, -79.3f, 0f);
        transform.localRotation = new Quaternion(-45f,0f,0f,0f);

    }
}
