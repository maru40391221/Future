using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerThird : MonoBehaviour
{
    public float health;

    //moving right and left
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    //

    // body-flipping
    private bool facingRight = true;
    //

    //jumping action   
    private bool isGrounded; 
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround; 
    public float jumpForce;
    private int extraJumps;
    public int extraJumpsValue;

    //

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }

    private void FixedUpdate() {
        //moving right and left
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
        //

        // body-fliping
        if (facingRight == false && moveInput > 0)
        {
            Flip ();
        }else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        //

        //jumping action
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //




    }

    private void Update() {

        //jumping action
        if (isGrounded == true)
        {
            extraJumps=extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps>0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        //

        
    }

    // body-flipping
    void Flip (){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
            //health
    public void TakeDamage (int damageAmount) {
        health -= damageAmount;
        if (health<=0) {
            Destroy(gameObject);
            Debug.Log("GameOver");
        }
        
    }
}
