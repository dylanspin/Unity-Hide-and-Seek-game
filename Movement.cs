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

    public float WalkingSpeed = 12.0f;
    public float RuningSpeed = 14.0f;
    public float crouchingSpeed = 7.0f;
    public float jumpHeight = 3.0f;
    public float gravity = -9.81f;
    public float speed = 15.0f;
    private Vector3 velocity;

    void Update()
    {
        // if(ismine)
        // {
            isGrounded = controller.isGrounded;
            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;   
            }

            float z = Input.GetAxis("Vertical");
            float x = Input.GetAxis("Horizontal");

            
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);//movement

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);//gravity
        // }
    }
}
