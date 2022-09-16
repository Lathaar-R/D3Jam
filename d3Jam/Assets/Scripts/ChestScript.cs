using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour, Iinteractable
{
    private Collider2D _chestCollider;
    private List<Collider2D> _overlapResults = new();
    private List<Item> _chestItems = new();
    
    public Item[] chestItems;
    private InventorySlot[] _chestSlots;
    public int slotPos = 0;
    bool open;

    //[SerializeField] ContactFilter2D _contactFilter;
    [SerializeField] private GameObject itemsParent;
    [SerializeField] private GameObject selection;


    void Start()
    {
        _chestCollider = GetComponent<Collider2D>();

        _chestSlots = itemsParent.GetComponentsInChildren<InventorySlot>();

        itemsParent.SetActive(false);

        int i = 0;
        foreach (var item in _chestSlots)
        {
            item.AddItem(chestItems[i]);
            i++;
        }
        
    }


    
    void Update()
    {
        if(PlayerMovment.freePlayer || !open) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }

        if(Input.GetKeyDown(KeyCode.D)) slotPos++;
        if(Input.GetKeyDown(KeyCode.A)) slotPos--;
        slotPos = Mathf.Clamp(slotPos, 0, 5);
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var item = Instantiate(_chestSlots[slotPos].GetItem());
            //var item = _chestSlots[slotPos].GetItem();
            //Debug.Log(item.name);
        
            Inventory.instance.Add(item);
            Invoke("CloseMenu", Time.fixedDeltaTime);
        }
    

        UpdateUi();

        
    }

    private void CloseMenu()
    {
        slotPos = 0;
        itemsParent.SetActive(false);
        PlayerMovment.freePlayer = true;
        open = false;
    }

    public void OnInteract()
    {
        Invoke("ActivateMenu", Time.fixedDeltaTime);
        open = true;
    }

    void ActivateMenu()
    {
        itemsParent.SetActive(true);

        PlayerMovment.freePlayer = false;
    }

    void UpdateUi()
    {
        selection.transform.position = _chestSlots[slotPos].transform.position;
    }
}
