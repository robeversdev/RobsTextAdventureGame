using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller class to handle all the buttom press logic for the Player
/// </summary>
public class PlayerController
{
    private Player player;
    private enum ActiveScreen
    {
        ROOM,
        INVENTORY,
        ITEM,
    }

    private ActiveScreen activeScreen;

    public PlayerController() { }

    public PlayerController(Player newPlayer)
    {
        player = newPlayer;
        activeScreen = ActiveScreen.ROOM;
    }

    public string ListenToAllInput()
    {
        switch(activeScreen)
        {
            case ActiveScreen.ROOM:
                ListenForRoomInput();
                break;
            case ActiveScreen.INVENTORY:
                ListenForInventoryInput();
                break;
            case ActiveScreen.ITEM:
                ListenForItemInput();
                break;
        }

        return BuildTextForScreen();
    }

    /// <summary>
    /// Checks what the active screen is and returns the text associated with it
    /// </summary>
    /// <returns></returns>
    private string BuildTextForScreen()
    {
        switch(activeScreen)
        {
            case ActiveScreen.ROOM:
                return player.GetRoomPlayerIsIn().GetStateStory();
            case ActiveScreen.INVENTORY:
                return player.GetPlayerInventory().BuildInventoryText();
            case ActiveScreen.ITEM:
                return player.GetPlayerInventory().PrintItemPage(player.GetPlayerInventory().GetOpenItemSlot());

        }

        return "";
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
        else if (Input.GetKeyDown(KeyCode.I) && activeScreen == ActiveScreen.ROOM)
        {
            activeScreen = ActiveScreen.INVENTORY;
        }


    }
    /// <summary>
    /// Listens for input while on the inventory screen
    /// </summary>
    public void ListenForInventoryInput()
    {
        //TODO build inventory actions like examine, use and drop
        // Probably need to limit inventory space to start with

        // if I is pressed we swap back to ROOM controls
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeScreen = ActiveScreen.ROOM;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeScreen = ActiveScreen.ITEM;
            player.GetPlayerInventory().OpenItemSlot(Assets.ItemSlotBeingExamined.SLOT1);
            //player.GetPlayerInventory().PrintItemPage(1);
        }
    }
    
    public void ListenForItemInput()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            activeScreen = ActiveScreen.INVENTORY;
        }
    }
}
