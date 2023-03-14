using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{     
    public int health;
    [HideInInspector]
    public Transform player;
    public float speed;
    public float timeBetweenAttacks;
    public int damage;
    public float minX;
    public float maxX;
    private Vector2 targetPosition;
    public float timeBetweenSummons;
    private float summonTime;
    public GameObject enemyToSummon;


    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float randomX = Random.Range(minX,maxX);
        targetPosition = new Vector2 (randomX, transform.position.y);
    }

    private void Update() {
        if (player != null)
        {
            if (Vector2.Distance (transform.position, targetPosition) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        } else 
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
