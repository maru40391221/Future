using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{     

    public float timeBetweenSummons;
    private float summonTime;
    public GameObject enemyToSummon;

    public float Speed;
    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;

    public float startWaitTime;


    public override void Start() 
    {
        base.Start();
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update() 
    {

        if (player != null)
        {
           
            if (Time.time >= summonTime)
            {
                summonTime = Time.time + timeBetweenSummons;
                summon();
            }
        }

        transform.position = Vector2.MoveTowards (transform.position, moveSpots[randomSpot].position, Speed*Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f )
        {
            if (waitTime <= 0){
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }else{
            waitTime -= Time.deltaTime;
            }

        }

        

    }

    public void summon (){
        if (player != null){
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    }

}

    




