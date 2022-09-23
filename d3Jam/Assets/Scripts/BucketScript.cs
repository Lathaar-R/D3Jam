using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour, Igrabbable
{
    SpriteRenderer _spriteRenderer;

    public static bool full;
    public Item emptyBucket;
    public Item fullBucket;

    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = emptyBucket.icon;
    }

    public void Drop(UnityEngine.Vector3 newPos)
    {
        if(full)
            _spriteRenderer.sprite = fullBucket.icon;
        else
        {
            _spriteRenderer.sprite = emptyBucket.icon;
        }

        transform.position = newPos;
    }

    public void OnInteract()
    {
        if(Inventory.instance.equipedItem)
            Inventory.instance.UnequipItem();

        if(full)
            Inventory.instance.EquipItem(fullBucket);
        else
            Inventory.instance.EquipItem(emptyBucket);

        
        transform.position = new(-1000, 1000);
    }


}
