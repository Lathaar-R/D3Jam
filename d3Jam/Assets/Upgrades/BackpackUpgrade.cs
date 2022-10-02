using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUpgrade : UpgradeSlot
{
    public GameObject newInventory;

    public override void Upgrade()
    {
        DataManager.instance.inventorySpace = 12;

        DataManager.instance.inventoryUI = newInventory;
        //Inventory.instance.reactTransform = reactTransform;
        Debug.Log("COMPROU MOCHILA");
    }
}