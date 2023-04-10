using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : generalEnemy
{
    public float minX;
    public float maxX;
    private Vector2 targetPosition;

    public float timeBetweenSummons;
    private float summonTime;
    public GameObject enemyToSummon;
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX,maxX);
        float currentY = transform.position.y;
        targetPosition = new Vector2 (randomX, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance (transform.position, targetPosition) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                
            } else
            {
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    summon();
                }
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

