using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public int damage;
    void Start()
    {
        Destroy(gameObject, lifeTime);

    }

    private void Update() {
        transform.Translate(Vector2.left *speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag == "Enemy") {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}





