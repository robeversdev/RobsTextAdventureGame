﻿using System.Collections;
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

    public string EnterRoom()
    {
        string currentText = GetStateStory();
        if(storyText.Length -1 > numberOfTimesEntered)
            numberOfTimesEntered++;

        return currentText;
    }


}
