using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Transform fpsCamera;
    public float range = 5.0f;
    public LayerMask Mask;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward , out hit , range,Mask))
            { 
                fInputs(hit,fpsCamera.transform.position,fpsCamera.transform.forward);
            }
        }
    }

    void fInputs(RaycastHit hit,Vector3 pos , Vector3 angle)
    {
        if(hit.transform.tag == "Door")
        {   
            Debug.Log("test");
            hit.transform.GetComponent<DoorTrigger>().checkInteract();   
        }else if(hit.transform.tag == "Button")
        {   
            hit.transform.parent.transform.GetComponent<CodeLock>().PressButton(hit.transform); 
        }
    }

}
