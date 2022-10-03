using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaso : MonoBehaviour, Iinteractable
{
    public Plant plantaDoVaso; 
    public Sprite baseSprite;

    private SpriteRenderer _spriteRenderer;

    bool readyPlant;
    float growing;

    public int stage = 0;

    
    void Start()
    {
        transform.position = Vector3Int.FloorToInt(transform.position);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
       if(!readyPlant)
       {
            if(plantaDoVaso)
                if((plantaDoVaso.needsToGrow[stage] == "Luz") && Physics2D.OverlapBox(transform.position, Vector2.one, 0, LayerMask.NameToLayer("Light")))
                {
                    growing += Time.deltaTime * DataManager.instance.soilMultiplyer;
                    Debug.Log("Luz na planta");

                    if(growing >= plantaDoVaso.growTime)
                    {
                        UpgradePlant();
                        
                    }
                }
       }
       else
       {
            
       }
    }
    

    public bool PlantOnVase(Plant plant)
    {
        if(plantaDoVaso == null)
        {
            plantaDoVaso = plant;

            _spriteRenderer.sprite = plantaDoVaso.plantSprites[stage];

            return true;
        }

        return false;
        
    }

    void UpgradePlant()
    {
        ++stage;

        //Debug.Log(stage);
        _spriteRenderer.sprite = plantaDoVaso.plantSprites[stage];
        if(stage >= plantaDoVaso.needsToGrow.Count)
        {
            Debug.Log("Planta finalizada!");
            readyPlant = true;
        }
    }

    public void OnInteract()
    {
        
        if(readyPlant)
        {
            if(Inventory.instance.items.Count <= DataManager.instance.inventorySpace)
            {
                Inventory.instance.Add(plantaDoVaso.finishItem);
                _spriteRenderer.sprite = baseSprite;
                plantaDoVaso = null;
                readyPlant = false;
                stage = 0;
                growing = 0;
            }

            return;
        }        


        Debug.Log("interagindo com o vaso");
        if(Inventory.instance.equipedItem == null) return;

        if(plantaDoVaso == null)
        {
            Debug.Log("Tentando Plantar");
            if(Inventory.instance.equipedItem.id == itemType.semente)
            {
                Debug.Log("Plantando");
                var itemEquipped = Inventory.instance.equipedItem;
                var plant = DataManager.instance.plantsReferences.First(obj => obj.plantName == itemEquipped.itemName);
                
                Inventory.instance.UnequipItem();
                Inventory.instance.Remove(itemEquipped);

                PlantOnVase(plant);
                stage = 0;
            }
        }
        else
        {

            if(Inventory.instance.equipedItem.itemName.Equals(plantaDoVaso.needsToGrow[stage]))
            {
                Debug.Log("Crescendo a planta");

                Inventory.instance.Remove(Inventory.instance.equipedItem);
                Inventory.instance.UnequipItem();
                

                UpgradePlant();
            }
            
        }
    }
}


