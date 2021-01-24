using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;
    float defaultPosY = 0;
    float timer = 0;
    public float x = 0;
    public float z = 0;

    private bool isActive = true;

    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    public void setDef(float newheight)
    {
        defaultPosY = newheight;
    }

    void Update()
    {
        if(isActive)
        {
            if(Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f)
            {
                timer += Time.deltaTime * walkingBobbingSpeed;
                transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
                x = 0;
                z = 0;
            }else{
                timer = 0;
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
            }
        }
    }

    public void setValues(float newX, float newZ)
    {
        x = newX;
        z = newZ;
    }

    public void setBobingSpeed(bool active)
    {
        if(active)
        {
            walkingBobbingSpeed = 20;
            bobbingAmount = 0.03f;
        }else{
            walkingBobbingSpeed = 12;
            bobbingAmount = 0.02f;
        }
    }

    public void turnOfBobing(bool active)
    {
        if(active)
        {
            isActive = true;
        }else{
            isActive = false;
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}
