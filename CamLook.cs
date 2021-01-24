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


    void Start()
    {
        // // Debug.Log(save.loadOptions().Sens+" som : " + save.loadOptions().Sens / 100);
        // if(save.loadOptions() != null)
        // {
        //     if((float)save.loadOptions().Sens <= 0.1f)
        //     {
        //         sensitivity = 3f * 0.1f;
        //     }else{
        //         sensitivity = 3f * (float)((float)save.loadOptions().Sens  / 100);
        //     }
        // }else{
        //     sensitivity = 1.5f;
        // }
    }
    
    void Update ()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngel);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);


        // float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        // float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        // yRotation -= mouseX;
        // yRotation = Mathf.Clamp(yRotation, -60, 60);

        // xRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation, minAngle, maxAngel);

        
        // transform.localRotation = Quaternion.Euler(xRotation,-yRotation,0f); 
                
    }
}
