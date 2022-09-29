using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellScript : MonoBehaviour, Iinteractable
{
    [SerializeField] Item water;
    [SerializeField] int waterTime;
    

    public void OnInteract()
    {
        if(Inventory.instance.items.Count < Inventory.instance.space)
        {
            var newWater = Instantiate(water);

            Inventory.instance.Add(newWater);

            PlayerMovment.freePlayer = false;

            Invoke("finishWater", waterTime);
        }
    }

    void finishWater()
    {
        PlayerMovment.freePlayer = true;
    }

    
}