using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{     
    public int health;
    [HideInInspector]
    public Transform player;
    public float timeBetweenSummons;
    private float summonTime;
    public GameObject enemyToSummon;


    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if (player != null)
        {
            if (Time.time >= summonTime)
            {
                summonTime = Time.time + timeBetweenSummons;
                Instantiate(enemyToSummon, transform.position, transform.rotation);

            }

        }
    }

    public void TakeDamage (int damageAmount) 
   {
    health -= damageAmount;
    if (health<=0) {
        Destroy(gameObject);
    }
   }

}
