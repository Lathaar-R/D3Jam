using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;          // Reference to the Icon image
    public Button removeButton;
    //public GameObject itemFocus;

    Item item = null;  // Current item in the slot

    /*private void Awake()
    {
        itemFocus = GameObject.Find("ItemFocus");
    }

    private void Start()
    {
        itemFocus.SetActive(false);
    }*/

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    // Called when the item is pressed
    public void UseItem()
    {
        /*if (item != null)
        {
            itemFocus.GetComponentsInChildren<Image>()[1].sprite = item.icon;
            itemFocus.GetComponentInChildren<TextMeshProUGUI>().text = item.description;
            itemFocus.SetActive(true);
        }*/
    }

    public Item GetItem()
    {
        return item;
    }

}