﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    string playerName;
    string genderOfPlayer;
    Inventory playerInventory;
    List<string> routesToComplete;
    State roomPlayerIsIn;
    PlayerController controller;

    public Player(State startingRoom)
    {
        playerName = "Rin";
        genderOfPlayer = "Female";
        playerInventory = new Inventory();
        routesToComplete =  new List<string>(new string[] { "North", "South", "East", "West" });
        roomPlayerIsIn = startingRoom;
        playerInventory.PopulateInventoryWithTestValues(); // Test code to pre-populate inventory with silly objects
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

    public State GetRoomPlayerIsIn()
    {
        return roomPlayerIsIn;
    }

    public void MoveIntoRoom(State newRoom)
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

}
