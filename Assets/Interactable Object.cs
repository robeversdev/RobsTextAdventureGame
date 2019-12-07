using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject
{
    protected string ObjectDescription;
    protected string ObjectName;
    protected string PickUpAttemptResponse;

    public InteractableObject() { }
    public InteractableObject(string description, string name)
    {
        ObjectDescription = description;
        ObjectName = name;
    }
    
    public string AttemptToPickUp()
    {
        return PickUpAttemptResponse;
    }

    public string ExamineObject()
    {
        return ObjectDescription + "\n\n\n\n" + GetObjectActions();
    }

    public string GetItemName()
    {
        return ObjectName;
    }

    /// <summary>
    /// The available actions to interact with this object
    /// </summary>
    /// <returns></returns>
    protected abstract string GetObjectActions();
}
