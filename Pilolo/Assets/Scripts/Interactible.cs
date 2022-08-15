using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;
using TMPro;

public class Interactible : NetworkBehaviour
{
   
    public bool isInRange;
    public bool isOpen;
    public bool isDoor;
    public bool isStickhere;
    public string popUp;
    public GameObject popUpBox;
    public Animator popUpAnimator;
    public TMP_Text popUpText;
    public Animator animator;
    
   
    public KeyCode interactKey;
    public UnityEvent interactAction;
    void Update(){
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                OpenCabinet();                
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
            Close();
            Debug.Log("Player is not in range");
        }
    }
    public void OpenCabinet(){
        if(isOpen == false){
            if(isDoor == true){
                
            }
            isOpen = true;
            Debug.Log("Chest Open");
            animator.SetBool("IsOpen", isOpen);
            
            if(isStickhere == hasStick){
                isStickhere = hasStick;
                Debug.Log("You have found a stick");
                Pop(popUp);
            }
        }
    }
   
    bool hasStick{
        get {return (Random.value > 0.5f );}
    }

     public void Pop(string text){
        popUpBox.SetActive(true);
        popUpText.text = text;
        popUpAnimator.SetTrigger("pop");
    }

    public void Close(){
        popUpBox.SetActive(false);
        popUpAnimator.SetTrigger("close");
    }    
}
