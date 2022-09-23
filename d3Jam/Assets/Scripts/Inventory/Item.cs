using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public string itemName = "New Item";    // Name of the item
    public Sprite icon = null;              // Item icon
    public Sprite sprite = null;
    public itemType id;

    [TextArea(5, 100)]
    public string description;

    // Called when the item is pressed in the inventory
    /*
    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
    */

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}

[System.Serializable]
public enum itemType
{
    NONE,
    semente,
    agua,
    luz,
    planta,
    animal
}