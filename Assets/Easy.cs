using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : Enemy
{

    public float stopDistance;
    public float speed;
    private float attackTime;
    public float timeBetweenAttacks;
    public float attackSpeed;

    public int damage;

    public override void Start()
    {
        base.Start();
    }

    private void Update() 
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
            }else 
            {
                if (Time.time >=attackTime){
                     StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                     }
                
            }
        
        }
        
        IEnumerator Attack() 
        {
            player.GetComponent<PlayerController>().TakeDamage(damage);

            Vector2 originalPosition = transform.position;
            Vector2 targetPosition = player.position;
            float percent = 0;
            while (percent<= 1)
            {
                percent += Time.deltaTime * attackSpeed;
                float formula = (-Mathf.Pow (percent, 2) + percent) * 4;
                transform.position = Vector2.Lerp (originalPosition, targetPosition, formula);
                yield return null;
            }
        }


    }



}
