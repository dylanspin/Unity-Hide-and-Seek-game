using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTraps : MonoBehaviour
{
    public Animator trapAnim;
    public string animationName = "MiniGun";
    private bool triggerd = false;
    public bool reset = true;
    public float resetTime = 20.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(!triggerd)
        {
            if(other.transform.tag == "Player")
            {
                trapTriggerd();
            }
        }
    }


    private void trapTriggerd()
    {
        if(!triggerd)
        {
            triggerd = true;
            trapAnim.Play(animationName);
            if(reset)
            {
                Invoke("resetTrap",resetTime);
            }
        }
    }


    private void resetTrap()
    {
        triggerd = false;
    }   
}
