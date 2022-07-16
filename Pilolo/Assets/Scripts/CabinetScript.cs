using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetScript : MonoBehaviour
{

    public bool isOpen;
    public Animator animator;
    

    public void OpenChest(){
        if(isOpen == false){
            isOpen = true;
            Debug.Log("Chest Open");
            animator.SetBool("IsOpen", isOpen);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
         if(collision.gameObject.CompareTag("Player")){
            Debug.Log("Player is in range of the chest");
            OpenChest();            
        }
    }*/
}
