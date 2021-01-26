using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private int amountTriggerd = 0;
    public Animator anim;
    public string bools = "Open";
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            checkOpen();
        }
    
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            checkClose();
            Debug.Log("test");
        }
    }

    void checkOpen()
    {   
        if(amountTriggerd == 0)
        {
            amountTriggerd = 1;
            anim.SetBool(bools,true);
        }else{
            amountTriggerd ++;
        }
    }

    void checkClose()
    {
        if(amountTriggerd == 1)
        {
            amountTriggerd = 0;
            anim.SetBool(bools,false);
            Debug.Log("test");
        }else{
            amountTriggerd --;
        }
    }   

    public void checkInteract()
    {
        if(amountTriggerd == 0)
        {
            amountTriggerd = 1;
            anim.SetBool(bools,true);
        }else{
            amountTriggerd = 0;
            anim.SetBool(bools,false);
        }
    }
}
