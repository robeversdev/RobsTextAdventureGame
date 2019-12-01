﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InanimateObject : InteractableObject
{
    public InanimateObject(string description, string name) : base(description, name) { }

    public string UseItem()
    {
        return "You have used " + this.ObjectName;
    }
}