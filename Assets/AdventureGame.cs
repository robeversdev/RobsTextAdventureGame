using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // Testing GIT by making this comment
    [SerializeField] Text textComponent; // this variable is set in the Unity client itself. The SerializeField property allows us to do this.
    [SerializeField] Room startingState;
    Player playerCharacter;
    public GameObject theCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = new Player(startingState);
        textComponent.text = playerCharacter.GetRoomPlayerIsIn().GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = playerCharacter.GetPlayerController().ListenToAllInput();
        //theCanvas.SetActive(playerCharacter.GetPlayerController().IsGameCanvasShowing()); // proof of concept for hiding the canvas
    }

}
