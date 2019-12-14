using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{

    List<InanimateObject> itemsInInventory;
    ItemSlotBeingExamined openSlot;

    public Inventory()
    {
        itemsInInventory = new List<InanimateObject>();
        //PopulateInventoryWithTestValues(); // Test code to pre-populate inventory with silly objects
    }

    private void PopulateInventoryWithTestValues()
    {
        for(int i = 0; i <= 4; i++)
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

    public int GetNumberOfFilledSlots()
    {
        return itemsInInventory.Count;
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
        return "Inventory \n" + PrintOutInventory();
    }

    private string PrintOutInventory()
    {

        string printedList = "";
        int numberOfItem = 1;

        if (GetAllItemsInInventory().Count == 0)
            return "You have no items in your inventory.";

        foreach(InanimateObject item in GetAllItemsInInventory())
        {
            printedList = printedList + "\n\n" + numberOfItem + ". " + item.GetItemName();
            numberOfItem++;
        }

        return printedList;
    }

    public string PrintItemPage(ItemSlotBeingExamined itemSlot)
    {
        switch(itemSlot)
        {
            case ItemSlotBeingExamined.SLOT1:
                return itemsInInventory[0].ExamineObject();
            case ItemSlotBeingExamined.SLOT2:
                return itemsInInventory[1].ExamineObject();
            case ItemSlotBeingExamined.SLOT3:
                return itemsInInventory[2].ExamineObject();
            case ItemSlotBeingExamined.SLOT4:
                return itemsInInventory[3].ExamineObject();
            case ItemSlotBeingExamined.SLOT5:
                return itemsInInventory[4].ExamineObject();
        }
        return "";
    }

    public void OpenItemSlot(ItemSlotBeingExamined slotToOpen)
    {
        openSlot = slotToOpen;
    }

    public ItemSlotBeingExamined GetOpenItemSlot()
    {
        return openSlot;
    }

    public string UseItemInOpenSlot()
    {
        switch (openSlot)
        {
            case ItemSlotBeingExamined.SLOT1:
                return itemsInInventory[0].UseItem();
            case ItemSlotBeingExamined.SLOT2:
                return itemsInInventory[1].UseItem();
            case ItemSlotBeingExamined.SLOT3:
                return itemsInInventory[2].UseItem();
            case ItemSlotBeingExamined.SLOT4:
                return itemsInInventory[3].UseItem();
            case ItemSlotBeingExamined.SLOT5:
                return itemsInInventory[4].UseItem();
        }
        return "";
    }
}
