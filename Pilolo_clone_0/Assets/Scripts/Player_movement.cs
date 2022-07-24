using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_movement : NetworkBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;
   

    Vector2 movement;

    void HandleMovement(){
        if(isLocalPlayer){
         //Sets x and y axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Sets the animtaions
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //Interactibles              
        }
    }


    // Update is called once per frame
    void Update()
    {

        HandleMovement();

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

   
}
