using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    AudioSource audioSource;

    GameObject inventoryUI;
    //public Canvas mainCanvas;
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

        audioSource = GetComponent<AudioSource>();
        var canvas = GameObject.Find("Canvas");

        inventoryUI = Instantiate<GameObject>(DataManager.instance.inventoryUI, canvas.transform);
        
        

        inventoryUI.SetActive(true);

        Invoke(nameof(CloseInventory), Time.fixedDeltaTime);
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


  // Amount of slots in inventory

    // Current list of items in inventory
    public List<Item> items = new List<Item>();

    //Equiped item reference
    public Item equipedItem;
    //public Carry equippedCarry;

    public bool open;
    public int slotPos = 0;
    public AudioClip openSound;
    public AudioClip closeSound;

    private void OnDestroy() {
        Destroy(inventoryUI);
    }

    private void Update()
    {
        if(PlayerMovment.freePlayer && !open)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Invoke("OpenInventory", Time.fixedDeltaTime);
            }
        }

        if(open)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                slotPos++;
                slotPos = Mathf.Clamp(slotPos, 0, items.Count - 1);
                onInventoryInteract?.Invoke();
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                slotPos--;
                slotPos = Mathf.Clamp(slotPos, 0, items.Count - 1);
                onInventoryInteract?.Invoke();
            }

            

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
            {
                Invoke("CloseInventory", Time.fixedDeltaTime);
            }

            if(Input.GetKeyDown(KeyCode.Space) && items.Count > 0)
            {         
                //Cannot equip with bucket in hand
                EquipItem(items[slotPos]);

                Invoke("CloseInventory", Time.fixedDeltaTime);
            }

            if(Input.GetKeyDown(KeyCode.H))
            {
                if(equipedItem == items[slotPos])
                    UnequipItem();

                Remove(items[slotPos]);
                Invoke("CloseInventory", Time.fixedDeltaTime);
            }
        }
    

        
    }

    void CloseInventory()
    {
        audioSource.PlayOneShot(closeSound);
        PlayerMovment.freePlayer = true;
        onOpenInventory?.Invoke();
        open = false;
    }

    void OpenInventory()
    {
        audioSource.PlayOneShot(openSound);
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
        if (items.Count >= DataManager.instance.inventorySpace)
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