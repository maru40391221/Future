using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public int health;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();

        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed; 


        if (moveInput != Vector2.zero)
    { 
        anim.SetBool("isRunning", true);
    }
    else 
    { 
        anim.SetBool("isRunning", false);
    }
    

    }
    


    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveAmount *Time.fixedDeltaTime);
    }


}

