using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    string playerName;
    string genderOfPlayer;
    Inventory playerInventory;
    List<string> routesToComplete;


    public Player()
    {
        playerName = "Rin";
        genderOfPlayer = "Female";
        playerInventory = new Inventory();
        routesToComplete =  new List<string>(new string[] { "North", "South", "East", "West" });

        playerInventory.PopulateInventoryWithTestValues(); // Test code to pre-populate inventory with silly objects
    }

    public List<string> GetRemainingRoutes()
    {
        return routesToComplete;
    }

    public string BuildCharacterStatusText()
    {
        string returnString;
        returnString = "Character Name: " + playerName + " \n";
        returnString = returnString + "Race: Human \n";
        returnString = returnString + "Gender: " + genderOfPlayer + " \n\n\n\n";
        returnString = returnString + playerInventory.BuildInventoryText();

        return returnString;

    }
}
