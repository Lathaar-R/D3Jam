using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    public GameObject inventoryUI;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
        //Debug.Log(Inventory.instance.gameObject.name);
    }


    #endregion

    private void Start() {

        inventoryUI.SetActive(false);
        inventoryUI.SetActive(true);
    }


    // Callback which is triggered when
    // an item gets added/removed.
    public delegate void OnItemChanged();
    public delegate void OnOpenInventory();
    public delegate void OnInventoryInteract();
    // Delegate to call when Interact button is pressed
    public OnItemChanged onItemIChanged;
    public OnOpenInventory onOpenInventory;
    public OnInventoryInteract onInventoryInteract;


    public int space = 6;  // Amount of slots in inventory

    // Current list of items in inventory
    public List<Item> items = new List<Item>();

    //Equiped item reference
    public Item equipedItem;
    //public Carry equippedCarry;

    public bool open;
    public int slotPos = 0;
    
    private void Update()
    {
        if(PlayerMovment.freePlayer && !open)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Invoke("OpenInventory", Time.fixedDeltaTime);
            }
        }

        if(open)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                slotPos++;
                slotPos = Mathf.Clamp(slotPos, 0, items.Count - 1);
                onInventoryInteract?.Invoke();
            }

            if(Input.GetKeyDown(KeyCode.A)) 
            {
                slotPos--;
                slotPos = Mathf.Clamp(slotPos, 0, items.Count - 1);
                onInventoryInteract?.Invoke();
            }

            

            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
            {
                Invoke("CloseInventory", Time.fixedDeltaTime);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {         
                //Cannot equip with bucket in hand
                EquipItem(items[slotPos]);

                Invoke("CloseInventory", Time.fixedDeltaTime);
            }
        }
    

        
    }

    void CloseInventory()
    {
        PlayerMovment.freePlayer = true;
        onOpenInventory?.Invoke();
        open = false;
    }

    void OpenInventory()
    {
        PlayerMovment.freePlayer = false;
        onOpenInventory?.Invoke();
        open = true;
    }

    // void OpenInventory()
    // {

    //     PlayerMovment.freePlayer = !PlayerMovment.freePlayer;
    //     inventoryUI.SetActive(!inventoryUI.activeSelf);
    //     Inventory.instance.open = !Inventory.instance.open;
    // }

    // Add a new item. If there is enough room we
    // return true. Else we return false.
    public bool Add(Item item)
    {
        // Check if out of space
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        items.Add(item);    // Add item to list

        // Trigger callback
        if (onItemIChanged != null)
            onItemIChanged.Invoke();

        return true;
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);     // Remove item from list

        // Trigger callback
        if (onItemIChanged != null)
            onItemIChanged.Invoke();
    }

    public void EquipItem(Item equipping)
    {
        
        equipedItem = equipping;
        onItemIChanged?.Invoke();
    }

    public void UnequipItem()
    {
        equipedItem = null;
        onItemIChanged?.Invoke();
    }
    
    // public void Interact()
    // {
    //     onInteractPressed?.Invoke();
    // }


}