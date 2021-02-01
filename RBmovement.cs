using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBmovement : MonoBehaviour
{   
    public Transform grounCheck;
    public float GroundDistance = 0.1f;
    public LayerMask groundMask;
    private Rigidbody rb;
    private Animator animator;
    public float speed;
    public float maxSpeed = 100.0f;
    public float jumpHeight = 3.0f;
    public SpinScript script;
    public TurretLook lookScript;
    public CamShake shakeScript;
    private bool disable = false;
    private bool jumping = false;
    private bool isGrounded = false;
    public Transform gun;
    private bool open = false;
    private bool shot = false;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(grounCheck.position,GroundDistance,groundMask);
        if(isGrounded)
        {
            if(jumping)
            {
                jumping = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            openDrone();
        }

        if(open)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shoot();
            }
        }

        if(!disable)
        {
            if(!jumping)
            {
                if(Input.GetKeyDown("space"))
                {
                    jumping = true;
                    isGrounded = false;
                    rb.AddForce(this.transform.up * jumpHeight);
                }
            }
        }
    }

    void FixedUpdate () 
    {
        if(!open)
        {
            float mV = Input.GetAxis ("Vertical");
            rb.AddForce(this.transform.forward * mV * speed);
            if(rb.velocity.magnitude > maxSpeed)
            {
                Debug.Log("MaxSpeed");
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            
            script.spinSpeed.x = mV * -1500;
        }
    }

    private void openDrone()
    {
        if(open)
        {
            open = false;
            animator.SetBool("Open",false);
            lookScript.unlock(false);
            script.enabled = true;
        }else{
            open = true;
            animator.SetBool("Open",true); 
            lookScript.unlock(true);
            script.enabled = false;
        }
    }

    private void shoot()
    {
        if(!shot && open)
        {
            shot = true;
            gun.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            gun.GetComponent<Animation>().Play();
            StartCoroutine(shakeScript.Shake(0.2f,0.05f));
            Invoke("resetShot",0.25f);
        }
    }

    void resetShot()
    {
        shot = false;
    }
}
