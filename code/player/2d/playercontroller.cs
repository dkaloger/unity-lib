using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
  public float z;
    public Animator animator;
    public ground gr ;
    public cut c;
  //  public stamina s;
    public float moveHorizontal;
    public float moveVertical;

    public float speed = 0.0f;
    Rigidbody rb ;
   public float gravity;
    public float airspeed = 0.0f;
    public bool cutenabled = false;
    Animation jump_up;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
 
    void FixedUpdate()
    {


           
    moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
       cutenabled = true;

        //if (//moveVertical < 0)
        //   {
        //      moveVertical = 0;
        //  }

        //   Debug.Log("l26");

        //   Debug.Log(moveVertical);
        if (moveVertical == 1)
        {
            moveHorizontal = moveHorizontal / airspeed;
        }
        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
        animator.SetInteger("horizontal", Mathf.RoundToInt(moveHorizontal));
        animator.SetInteger("vertical", Mathf.RoundToInt(moveVertical));
        transform.position = new Vector3(transform.position.x + moveHorizontal / speed, transform.position.y + moveVertical / gravity, transform.position.y +5);
      z=  transform.position.y +5;
          if(moveHorizontal > 0.1f)
       {
          transform.localRotation = new Quaternion(transform.localRotation.x, -180 ,transform.localRotation.z,0);
       }
       if (moveHorizontal<-0.1f)
        {
       transform.localRotation = new Quaternion(transform.localRotation.x, 0, transform.localRotation.z, 0);
        }
       if(moveVertical > 0.1f)
        {
            transform.localRotation = new Quaternion(transform.localRotation.x, -30, transform.localRotation.z, 0);

        }
        animator.SetInteger("I_speed", Mathf.RoundToInt(Mathf.Abs(moveHorizontal)));
         Debug.Log("air");
       //  if(s.fill == 0)
     //   {
    //        cutenabled = false;
      //  }
        
      
    //    if (Input.GetKey(KeyCode.Q) == true)
      //  {
       //     Debug.Log("kjlkj");
        //    cutenabled = true;
       //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
           
           
            // transform.Translate(movement * speed * Time.deltaTime, Space.World);
   
      
    }
}
