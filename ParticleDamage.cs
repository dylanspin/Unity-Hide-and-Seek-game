using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{   
    public int damage = 5;
    void OnParticleCollision(GameObject hitP)
    {    
        Debug.Log("hit");
        if(hitP.transform.tag == "Player")
        {
            hitP.gameObject.GetComponent<Hp>().takeDamage(damage);
        }
    }
}
