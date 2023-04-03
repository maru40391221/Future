using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;

    public int health;

    [HideInInspector]
    public Transform player;

    public virtual void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator> ();
    }

    public void TakeDamage (int damageAmount) 
   {
    health -= damageAmount;
    if (health<=0) {
        Destroy(gameObject);
    }

    
   }


}
