using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;   // The parent object of all the items
    public GameObject inventoryUI;  // The entire UI
    public GameObject selected;
    public InventorySlot equipedUI;

    Vector3 initialSelected;
    

    //Inventory inventory;    // Our current inventory

    InventorySlot[] slots;  // List of all the slots

    private void OnEnable() {
        Inventory.instance.onItemIChanged += UpdateUI;    // Subscribe to the onItemChanged callback
        Inventory.instance.onOpenInventory += OnpenInventory;
        Inventory.instance.onInventoryInteract += OnInventoryInteracted;
        
    }

    private void OnDisable() {
        Inventory.instance.onItemIChanged -= UpdateUI;    // Subscribe to the onItemChanged callback
        Inventory.instance.onOpenInventory -= OnpenInventory;
        Inventory.instance.onInventoryInteract -= OnInventoryInteracted;
    }

    void Start()
    {
        

        selected.transform.position = new(-1000, -1000);
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();


        Invoke("OnpenInventory", Time.fixedDeltaTime);
    }


    private void OnInventoryInteracted()
    {
        if(Inventory.instance.items.Count > 0)
            selected.transform.position = slots[Inventory.instance.slotPos].transform.position;
        else
            selected.transform.position = new(-1000, -1000);
    }

    private void OnpenInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        initialSelected = slots[0].transform.position;
        Inventory.instance.slotPos = 0;

        Debug.Log("OPEN");

    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    void UpdateUI()
    {
        if(Inventory.instance.equipedItem)
        {
            equipedUI.icon.sprite = Inventory.instance.equipedItem.icon;
        }
        else
        {
            equipedUI.icon.sprite = equipedUI.EmptyImage;
        }

        if(Inventory.instance.items.Count == 0)
            selected.transform.position = new(-1000, -1000);
        else
            selected.transform.position = slots[0].transform.position;

        // Loop through all the slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)  // If there is an item to add
            {
                slots[i].AddItem(Inventory.instance.items[i]);   // Add it

            }
            else
            {
                // Otherwise clear the slot
                slots[i].ClearSlot();
            }
        }
    }

        

        


}