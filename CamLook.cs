using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public Transform playerBody;
    float xRotation = 0.0f;
    float yRotation = 0.0f;
    public bool ismine = true; 
    public float minAngle = -65;
    public float maxAngel = 90;
    
    void Update ()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngel);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
                
    }
}
