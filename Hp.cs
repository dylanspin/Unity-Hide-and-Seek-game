using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public Transform SpawnPoint; 
    public CamShake shakeScript;
    public int hp = 100;
    public int maxHp = 100;
    private bool player = false;
    void Start()
    {
        if(this.transform.tag == "Player")
        {
            player = true;
        }
    }

    public void takeDamage(int damage)
    {
        if(damage > hp)
        {   
            this.gameObject.SetActive(false);
            if(player)
            {
                if(SpawnPoint)
                {
                    this.transform.position = SpawnPoint.position;
                }   
            }
            respawn();
        }else{
            hp -= damage;
            StartCoroutine(shakeScript.Shake(0.2f,0.1f));
        }
    }

    private void respawn()
    {
        this.gameObject.SetActive(true);
        hp = maxHp;
    }
}
