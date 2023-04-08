using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{    public float speed;
    public float lifeTime;
    public GameObject explosion;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectTile", lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector2.up *speed*Time.deltaTime);
    }
    void DestroyProjectTile(){
        Destroy (gameObject);
        Instantiate (explosion, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag == "Enemy") {
            collision.GetComponent<generalEnemy>().TakeDamage(damage);
            DestroyProjectTile();
        }
    }
}





