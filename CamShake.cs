using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public GameObject FpsCamera;
    private Vector3 originalPos;

    void Start()
    {
        originalPos = FpsCamera.transform.localPosition;
    }
    public IEnumerator Shake (float duration, float magnitude)
    {
            float elepsed = 0.0f;

            while(elepsed < duration)
            {
                float x = Random.Range(-2f,2f) * magnitude;
                float y = Random.Range(-0.2f,0.2f) * magnitude;
                
                FpsCamera.transform.localPosition = new Vector3(x,y,originalPos.z);

                elepsed += Time.deltaTime;

                yield return null;
            }

            FpsCamera.transform.localPosition = originalPos;
    }
}
