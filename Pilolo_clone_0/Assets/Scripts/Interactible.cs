using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public bool isInRange;
    public bool isOpen;
    public Animator animator;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    void Update(){
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                OpenCabinet();                
            }
        }    
        if(isInRange){
            if(Input.GetKeyDown(KeyCode.E)){
                CloseCabinet();                
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            isInRange = true;
            Debug.Log("Player is in range");
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Player")){
            isInRange = false;
            Debug.Log("Player is not in range");
        }
    }
    public void OpenCabinet(){
        if(isOpen == false){
            isOpen = true;
            Debug.Log("Chest Open");
            animator.SetBool("IsOpen", isOpen);
        }
    }

    public void CloseCabinet(){
        if(isOpen == true){
            isOpen = false;
            Debug.Log("Chest closed");
            animator.SetBool("IsOpen", isOpen);
        }
    }
}
