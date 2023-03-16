using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{     

    public float timeBetweenSummons;
    private float summonTime;
    public GameObject enemyToSummon;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Vector2 targetPosition;
    public float speed;


    public override void Start() 
    {
        base.Start();
        float randomX = Random.Range(minX,maxX);
        float randomY = Random.Range(minY,maxY);
        targetPosition = new Vector2 (randomX, randomY);

    }

    private void Update() {
        if (player != null)
        {
            if (Time.time >= summonTime)
            {
                summonTime = Time.time + timeBetweenSummons;
                Instantiate(enemyToSummon, transform.position, transform.rotation);

            } else {
            if (Vector2.Distance (transform.position, targetPosition) > .5f){
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            
            }
        }

    }


}
