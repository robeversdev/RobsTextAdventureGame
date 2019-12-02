using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string[] storyText;

    [SerializeField] State[] nextStates;

    List<InteractableObject> objectsInRoom;

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


}
