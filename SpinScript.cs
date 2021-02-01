using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public Vector3 spinSpeed = new Vector3(0.0f,0.0f,1000.0f);

    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime);
    }
}
