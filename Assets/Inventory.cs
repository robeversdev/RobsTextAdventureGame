using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    List<InanimateObject> itemsInInventory;

    public Inventory()
    {
        itemsInInventory = new List<InanimateObject>();
    }

    public void PopulateInventoryWithTestValues()
    {
        for(int i = 0; i <= 5; i++)
        {
            itemsInInventory.Add(new InanimateObject("This is the description for Object" + i, "TestObject" + i));
        }
    }

    public void PickUpItem(InanimateObject pickUp)
    {
        itemsInInventory.Add(pickUp);
    }

    public void DropItem(InanimateObject dropDown)
    {
        itemsInInventory.Remove(dropDown);
    }

    public List<InanimateObject> GetAllItemsInInventory()
    {
        return itemsInInventory;
    }

    public InanimateObject GetSpecificInventorySlot(int index)
    {
        return itemsInInventory[index];
    }

    public string PrintOutInventoryInteractableList(List<InanimateObject> itemsToInteract)
    {
        string interactableList = "";
        int buttonToPress = 1;

        foreach(InteractableObject item in itemsToInteract)
        {
            interactableList = interactableList + buttonToPress + ". " + item.GetItemName() + "\n\n";
        }

        if (interactableList.Equals(""))
            return "You have no items in your inventory";
        return interactableList;
    }


    public string BuildInventoryText()
    {
        return "Items in inventory: " + PrintOutInventory();
    }

    private string PrintOutInventoryActions()
    {
        return "1. Examine an Item   2. Use an Item";
    }

    private string PrintOutInventory()
    {
        string printedList = "";
        foreach (InanimateObject item in GetAllItemsInInventory())
        {
            if (itemsInInventory.IndexOf(item) == itemsInInventory.Count - 1) // if this is the last item then we don't need a comma separator
                printedList += item.GetItemName();
            else printedList = printedList + item.GetItemName() + ", ";
        }

        return printedList;
    }
}
