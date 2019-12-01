using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{

    [SerializeField] Text textComponent; // this variable is set in the Unity client itself. The SerializeField property allows us to do this.
    [SerializeField] State startingState;
    Player playerCharacter;

    string inventoryText = "Test inventory screen";
    bool keyPressFlag; 
    
    private State state; // the current active state

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = new Player();
        state = startingState;
        Debug.Log(startingState.GetNumberOfTimesEntered());
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
            keyPressFlag = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length >= 2)
        {
            state = nextStates[1];
            keyPressFlag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length >= 3)
        {
            state = nextStates[2];
            keyPressFlag = true;
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryText = playerCharacter.BuildCharacterStatusText();
            if (!textComponent.text.Equals(inventoryText))
                textComponent.text = inventoryText;
            else
                textComponent.text = state.GetStateStory();
        }

        if (keyPressFlag)
            textComponent.text = state.EnterRoom();

        keyPressFlag = false;
    }
}
