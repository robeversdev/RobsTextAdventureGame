using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    string playerName;
    string genderOfPlayer;
    Inventory playerInventory;
    List<string> routesToComplete;
    Room roomPlayerIsIn;
    PlayerController controller;

    public Player(Room startingRoom)
    {
        playerName = "Rin";
        genderOfPlayer = "Female";
        playerInventory = new Inventory();
        routesToComplete =  new List<string>(new string[] { "North", "South", "East", "West" });
        roomPlayerIsIn = startingRoom;
        controller = new PlayerController(this);
    }

    public List<string> GetRemainingRoutes()
    {
        return routesToComplete;
    }

    public string BuildCharacterStatusText()
    {
        string returnString;
        returnString = "Character Name: " + playerName + " \n";
        returnString += "Race: Human \n";
        returnString = returnString + "Gender: " + genderOfPlayer + " \n\n\n\n";
        returnString += playerInventory.BuildInventoryText();

        return returnString;

    }

    public Room GetRoomPlayerIsIn()
    {
        return roomPlayerIsIn;
    }

    public void MoveIntoRoom(Room newRoom)
    {
        roomPlayerIsIn = newRoom;
        roomPlayerIsIn.EnterRoom();
    }

    /// <summary>
    /// Return the Controller for the player
    /// </summary>
    /// <returns></returns>
    public PlayerController GetPlayerController()
    {
        return controller;
    }

    /// <summary>
    /// Returns the Inventory object belonging to the Player
    /// </summary>
    /// <returns></returns>
    public Inventory GetPlayerInventory()
    {
        return playerInventory;
    }

}
