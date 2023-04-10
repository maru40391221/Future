using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : generalEnemy
{
    public float timeBetweenSummons;
    private float summonTime;
    public GameObject enemyToSummon;
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    summon();
                }
            
        }
    }
    public void summon ()
    {
        if (player != null)
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    
        }
        
}

