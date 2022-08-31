using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Image actorImage; 
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message [] currentMessages;
    Actor [] currentActors;
    int activeMessages = 0;
    public static bool isActive = false;

    public void OpenDialog(Message[] messages, Actor[] actors){
        currentMessages = messages;
        currentActors = actors;
        activeMessages = 0;
        isActive = true;

        Debug.Log("Started Tutorial! Loaded Messages: " + messages.Length);
        DisplayMessages();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessages(){
        Message messageToDisplay = currentMessages[activeMessages];
        messageText.text = messageToDisplay.mesage;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColour();
    }

    void NextMessage(){
        activeMessages++;
        if(activeMessages < currentMessages.Length){
            DisplayMessages();
        }
        else{
            isActive = false;
            Debug.Log("Tutorial Ended");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        }
    }

    void AnimateTextColour(){
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isActive == true){
            NextMessage();
        }
    }
}
