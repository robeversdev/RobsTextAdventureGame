using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string[] storyText;

    string searchText;

    [SerializeField] State[] nextStates;

    [SerializeField] List<InteractableObject> objectsInRoom = new List<InteractableObject>();

    private int numberOfTimesEntered = 0;

    public string GetStateStory()
    {
        return storyText[numberOfTimesEntered];
    }

    /// <summary>
    /// Return the Rooms attached to the context Room
    /// </summary>
    /// <returns></returns>
    public State[] GetNextStates()
    {
        return nextStates;
    }

    private void PopulateObjectsInRoom()
    {
        objectsInRoom.Add(new InanimateObject("It's a Large Key", "Large Key"));
    }

    public int GetNumberOfTimesEntered()
    {
        return numberOfTimesEntered;
    }

    private string ListObjectsInRoom()

    { 
        string itemList = "";

        if (objectsInRoom.Count == 0)
            return itemList;

        int iterator = 1;
        foreach(InteractableObject obj in objectsInRoom)
        {
            itemList = itemList + iterator + ". " + obj.GetItemName() + "\n";
            iterator++;
        }

        return itemList;
    }

    /// <summary>
    /// Informs the room it has been entered and updates the current Room text based on how many times the room was entered 
    /// </summary>
    /// <returns></returns>
    public void EnterRoom()
    {
        if(storyText.Length -1 > numberOfTimesEntered)
            numberOfTimesEntered++;
        Debug.Log("Entered the room: " + numberOfTimesEntered + " times");
    }

    public string GetSearchText()
    {
        //return searchText;

        if(objectsInRoom.Count == 0)
        {
            return "You begin to search for items. \n\n There is nothing worth noting. ";
        }
        return "You begin to search for items. " + "\n\n Which items do you want to interact with? \n" + ListObjectsInRoom();
    }


}
