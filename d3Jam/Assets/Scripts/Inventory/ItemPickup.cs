using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.sprite;
        CheckInv();
    }

    private void OnMouseDown()
    {
        PickUp();
    }

    // Pick up the item
    public void PickUp()
    {
        Debug.Log("Picking up " + item.itemName);
        Inventory.instance.Add(item);   // Add to inventory

        Destroy(gameObject);    // Destroy item from scene
    }

    private void CheckInv()
    {
        int n = Inventory.instance.items.Count; 
        for(int i = 0; i < n; i++)
        {
            if(Inventory.instance.items[i].id == item.id)
            {
                Destroy(gameObject);
            }
        }
    }

}