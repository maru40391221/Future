using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : generalEnemy
{
 //summoning
    public float timeBetweenSummons;
    private float summonTime;
    public GameObject enemyToSummon;
 //summoning

 //moving

    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

//moving
    public override void Start()
    {
        base.Start();

        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
       transform.position = Vector2.MoveTowards (transform.position, moveSpots[randomSpot].position, speed*Time.deltaTime);
//summoning
        if (Time.time >= summonTime)
        {
                    summonTime = Time.time + timeBetweenSummons;
                    summon();
        }
 //summoning
            
        }
 //moving
 
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f )
        {
            if (waitTime <= 0){
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }else{
            waitTime -= Time.deltaTime;
            }

        }
 //moving


    }
    public void summon ()
    {
        if (player != null)
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    
        }
        
}

