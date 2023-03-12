using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    [HideInInspector]
    public Transform player;
    public float stopDistance;
    public float speed;
    private float attackTime;
    public float timeBetweenAttacks;
    public float attackSpeed;


    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            player.GetComponent<Player>().TakeDamage(damage);

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

        
   
   public void TakeDamage (int damageAmount) 
   {
    health -= damageAmount;
    if (health<=0) {
        Destroy(gameObject);
    }
   }

}
