using UnityEngine;


public class Player_movement : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;
   

    Vector2 movement;



    // Update is called once per frame
    void Update()
    {
        if(DialogManager.isActive == true){
            return;
        }

        //Sets x and y axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Sets the animtaions
        if(movement != Vector2.zero){
             animator.SetFloat("Horizontal", movement.x);
             animator.SetFloat("Vertical", movement.y);
        }
       
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //Interactibles              

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

   
}
