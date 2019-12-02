using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller class to handle all the buttom press logic for the Player
/// </summary>
public class PlayerController
{
    private Player player;


    public PlayerController() { }

    public PlayerController(Player newPlayer)
    {
        this.player = newPlayer;
    }

    /// <summary>
    /// Listen for input from the keyboard when inside a room
    /// </summary>
    public void ListenForRoomInput()
    {
        var nextStates = player.GetRoomPlayerIsIn().GetNextStates();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.MoveIntoRoom(nextStates[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length >= 2)
        {
            player.MoveIntoRoom(nextStates[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length >= 3)
        {
            player.MoveIntoRoom(nextStates[2]);
        }
/*        else if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryText = playerCharacter.BuildCharacterStatusText();
            if (!textComponent.text.Equals(inventoryText))
                textComponent.text = inventoryText;
            else
                textComponent.text = state.GetStateStory();
        }*/
    }
}
