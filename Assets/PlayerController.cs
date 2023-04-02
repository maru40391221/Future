using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded; 
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;  
    public float jumpForce;
    private int extraJumps;
    public int extraJumpsValue;

    public int health;

    private Animator anim;


    private void Start() {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
    }

    private void FixedUpdate() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
        
        if (facingRight == false && moveInput > 0)
        {
            Flip ();
        }else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps>0)
        {
            rb.velocity = Vector2.up * jumpForce;
            
        }
        {

        }

        if (rb.velocity != Vector2.zero){
            anim.SetBool("isRunning", true);
            }
        else {
            anim.SetBool("isRunning", false);
            }


    }

    private void Update() {

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


        
    }

    void Flip (){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void TakeDamage (int damageAmount) 
    {
        health -= damageAmount;
        if (health<=0) {
        Destroy(gameObject);
        }
    
    }



}
