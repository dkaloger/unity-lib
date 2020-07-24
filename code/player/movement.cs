using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float jump_stamina_loss;
    public float walk_stamina_loss;
    public stamina stamina;
  public  binocular E;
   public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
 public   Vector3 velocity;

 public   bool isGrounded;
    public float jumpHeight = 3f;
    public float sprint_speed = 24f;
float actual_speed = 12f;

    public Vector3 move;
    //climb
    public float climb_stamina_loss;
    public Vector3 forward;
    public Transform wallCheck;
    public bool touching_wall;

 public   bool Qtoggle;
    public float walllstick_stegnth;

    public Vector3 p1;
    public Vector3 p2;
    public float dis;
    public Vector3 fakef;
    public float climb_speed;

    public float maxgd;
    public bool sprinting;
    // Start is called before the first frame update
    void Start()
    {
        actual_speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(stamina.stamina_ok == false)
        {
            actual_speed = 6f;
        }
        if (stamina.stamina_ok == true)
        {
            actual_speed = speed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            sprinting = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            sprinting = false;

        }
        if(sprinting == true && stamina.stamina_ok == true)
        {
            actual_speed = sprint_speed;
        }
        forward = transform.TransformDirection(Vector3.forward) * walllstick_stegnth;
     
        isGrounded  = Physics.Raycast(transform.position,Vector3.down, maxgd); 
        float X = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        stamina.stamina_now -= jump_stamina_loss * Mathf.Clamp(velocity.y,0,Mathf.Infinity);
        if (Input.GetButton("Jump") && isGrounded && stamina.stamina_ok == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        
        }

        if ( !touching_wall || !Qtoggle &&stamina.stamina_ok == true)
        {
             move = transform.right * X + transform.forward * z;
            if(actual_speed == sprint_speed)
            {
                stamina.stamina_now -= walk_stamina_loss * (Mathf.Abs(move.x) + Mathf.Abs(move.y) + Mathf.Abs(move.z)) * actual_speed;
            }
         
            controller.Move(move * actual_speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }



    


        //sprint
   


        //climb

        if (Input.GetKeyDown(KeyCode.Q)){
            Qtoggle = !Qtoggle;
            E.binocular_enabled = false;
        }

    touching_wall = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), dis);
    

        if (touching_wall  && Qtoggle && stamina.stamina_ok == true)
        {
             move = transform.right * X + transform.up * z ;
            move += forward;
            //   move+= transform.position.forward;
            stamina.stamina_now -= climb_stamina_loss *  Mathf.Abs(move.y)  ;
            controller.Move(move * climb_speed * Time.deltaTime);
        }
    }
}
