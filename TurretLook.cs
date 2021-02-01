using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public Transform playerBody;
    float xRotation = 0.0f;
    float yRotation = 0.0f;
    public bool ismine = true; 
    public float minAngle = -65;
    public float maxAngel = 90;
    public Transform center;
    private bool open = false;
    public Camera[] cams = new Camera[2];
    
    void Update ()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        float x = Input.GetAxis("Horizontal") * sensitivity * 0.5f;
    
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngel);

        if(!open)
        {
            playerBody.Rotate(Vector3.up * mouseX);
            playerBody.Rotate(Vector3.up * x); //kan beter..
            transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        }else{
            center.localRotation = Quaternion.Euler(-xRotation,0f,0f);
        }
    }

    public void unlock(bool unlock)
    {
        open = unlock;
        if(unlock)
        {
            center.localRotation = Quaternion.Euler(0,0,0);
            cams[0].enabled = true;
            cams[1].enabled = false;
        }else{
            transform.localRotation = Quaternion.Euler(0,0,0);
            cams[0].enabled = false;
            cams[1].enabled = true;
        }
    }
}
