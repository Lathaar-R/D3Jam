using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaso : MonoBehaviour, Iinteractble
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

    public void OnClick(PlayerHands player)
    {
        //Debug.Log("A");
        if(player.equippedItem.Equals(plantaDoVaso.needsToGrow[plantaDoVaso.stage]))
        {
            plantaDoVaso.stage++;
            _spriteRenderer.sprite = plantaDoVaso.plantSprites[plantaDoVaso.stage];
        }
    }
}


