using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform grounCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded = false;

    public bool running = false;
    private bool crouching = false;
    public bool jumping = false;
    private bool jumpingAllowed = true;
    public float WalkingSpeed = 12.0f;
    public float RuningSpeed = 14.0f;
    public float crouchingSpeed = 7.0f;
    public float jumpHeight = 3.0f;
    public float gravity = -9.81f;
    public float speed = 15.0f;
    private Vector3 velocity;
    public Bobbing bobbingScript;
    private bool disable = false;

    void Update()
    {
        // if(ismine)
        // {
            if(!disable)
            {   

                isGrounded = controller.isGrounded;
                if(isGrounded)
                {
                    if(jumping)
                    {
                        jumping = false;
                    }
                }
                Jump();
                run();
                if(isGrounded && velocity.y < 0)
                {
                    velocity.y = -2f;   
                }

                float z = Input.GetAxis("Vertical");
                float x = Input.GetAxis("Horizontal");

                bobbingScript.setValues(x,z);
                
                Vector3 move = transform.right * x + transform.forward * z;

                controller.Move(move * speed * Time.deltaTime);//movement
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);//gravity

            
        // }
    }

    void Jump()
    {
        if(!disable)
        {
            if(jumpingAllowed && !crouching)
            {
                if(!jumping)
                {
                    if(Input.GetKeyDown("space"))
                    {
                        jumping = true;
                        isGrounded = false;
                        BoostUp(jumpHeight);
                    }
                }
            }
        }
    }


    void run()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {   
            running = true;
            speed = RuningSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            running = false;
            speed = WalkingSpeed;
        }
    }
    
    //disables and enables movement for ui
    public void setMovement(bool active)
    {
        disable = active;
    }

    public void BoostUp(float Height)
    {
        velocity.y = Mathf.Sqrt(Height * -2 * gravity);
    }

}
