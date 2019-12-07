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
        ITEMUSE,
        ITEMDROP, 
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
            case ActiveScreen.ITEMUSE:
                ListenForItemUseInput();
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
            case ActiveScreen.ITEMUSE:
                return player.GetPlayerInventory().UseItemInOpenSlot();

        }

        return "";
    }

    /// <summary>
    /// Listen for input from the keyboard when inside a room
    /// </summary>
    private void ListenForRoomInput()
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
    private void ListenForInventoryInput()
    {
        //TODO build inventory actions like examine, use and drop
        // Probably need to limit inventory space to start with

        // if I is pressed we swap back to ROOM controls
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeScreen = ActiveScreen.ROOM;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && player.GetPlayerInventory().GetNumberOfFilledSlots() >= 1)
        {
            activeScreen = ActiveScreen.ITEM;
            player.GetPlayerInventory().OpenItemSlot(Assets.ItemSlotBeingExamined.SLOT1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && player.GetPlayerInventory().GetNumberOfFilledSlots() >= 2)
        {
            activeScreen = ActiveScreen.ITEM;
            player.GetPlayerInventory().OpenItemSlot(Assets.ItemSlotBeingExamined.SLOT2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && player.GetPlayerInventory().GetNumberOfFilledSlots() >= 3)
        {
            activeScreen = ActiveScreen.ITEM;
            player.GetPlayerInventory().OpenItemSlot(Assets.ItemSlotBeingExamined.SLOT3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && player.GetPlayerInventory().GetNumberOfFilledSlots() >= 4)
        {
            activeScreen = ActiveScreen.ITEM;
            player.GetPlayerInventory().OpenItemSlot(Assets.ItemSlotBeingExamined.SLOT4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && player.GetPlayerInventory().GetNumberOfFilledSlots() >= 5)
        {
            activeScreen = ActiveScreen.ITEM;
            player.GetPlayerInventory().OpenItemSlot(Assets.ItemSlotBeingExamined.SLOT5);
        }
    }
    
    private void ListenForItemInput()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            activeScreen = ActiveScreen.INVENTORY;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeScreen = ActiveScreen.ITEMUSE;
        }
    }

    private void ListenForItemUseInput()
    {
        if (Input.GetKeyDown(KeyCode.B))
           activeScreen = ActiveScreen.INVENTORY;    
    }
}
