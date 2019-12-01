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
            itemsInInventory.Add(new InanimateObject("This is the description for Object" + i, "Object" + i));
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

    private string PrintOutInventory()
    {
        string printedList = "";
        foreach (InanimateObject item in GetAllItemsInInventory())
        {
            if (itemsInInventory.IndexOf(item) == itemsInInventory.Count - 1)
                printedList += item.GetItemName();
            else printedList = printedList + item.GetItemName() + ", ";
        }

        return printedList;
    }

    public string BuildInventoryText()
    {
        return "Items in inventory: " + PrintOutInventory();
    }
}
