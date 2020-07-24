using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godcam : MonoBehaviour
{
    [Range(7,30)] public float scrollSpeed = 5f;
    public bool canScroll = true;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movevelocity;
    public  Vector3 leftsidelimits;
    public Vector3 rightsidelimits;
    Vector2 roundedpos;
    [SerializeField] private GameObject lerpTarget;
    [SerializeField] private float cam_speed = 1f;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    void Update()
    {
        if (GetComponent<Camera>().orthographicSize <= 10 )
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && canScroll == true)
            {
                GetComponent<Camera>().orthographicSize += scrollSpeed * Time.deltaTime;
            }
        }
        if (GetComponent<Camera>().orthographicSize >= 3)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && canScroll == true)
            {
                GetComponent<Camera>().orthographicSize -= scrollSpeed * Time.deltaTime;
            }
        }
        if (GetComponent<Camera>().orthographicSize < 1)
        {
            GetComponent<Camera>().orthographicSize = 1;
        }
        else if (GetComponent<Camera>().orthographicSize > 10)
        {
            GetComponent<Camera>().orthographicSize = 10;
        }
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, lerpTarget.transform.position, cam_speed);
    }

    private void FixedUpdate()
    {
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        movevelocity = moveinput.normalized*  speed* Time.deltaTime *GetComponent<Camera>().orthographicSize;
           
            rb.MovePosition( rb.position + movevelocity);
        
 
           
        
        
    }

    public void CantScroll()
    {
        canScroll = false;
    }
    public void CanScroll()
    {
        canScroll = true;
    }
}