using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaso : MonoBehaviour, Iinteractable
{
    public Plant plantaDoVaso; 

    private SpriteRenderer _spriteRenderer;

    
    void Start()
    {
        transform.position = Vector3Int.FloorToInt(transform.position);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }
    

    public bool PlantOnVase(Plant plant)
    {
        if(plantaDoVaso == null)
        {
            plantaDoVaso = plant;

            _spriteRenderer.sprite = plantaDoVaso.plantSprites[0];

            return true;
        }

        return false;
        
    }

    public void OnInteract()
    {
        if(Inventory.instance.equipedItem.id == itemType.semente)
        {
            var s = Inventory.instance.equipedItem.name;

            switch (s)
            {
                // case "Tomate":

                // default:
            }
        }
    }
}


