using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour, Iinteractable
{
    private Collider2D _clientCollider;
    private SpriteRenderer _wantSprite;
    public Item item;
    public int bonusCoins;

    SpawnerScript _spawner;

    GameObject want;

    void Start()
    {
        StartCoroutine("BonusTimer");
        _clientCollider = GetComponent<Collider2D>();

        _wantSprite = GetComponentsInChildren<SpriteRenderer>()[1];
        _wantSprite.sprite = item.icon;

        _spawner = GameObject.Find("ClientSpawner").GetComponent<SpawnerScript>();
    }

    

    void Update()
    {
        
    }

    public void OnInteract()
    {
        if(Inventory.instance.equipedItem && Inventory.instance.equipedItem.itemName == item.itemName && Inventory.instance.equipedItem.id == itemType.planta)
        {
            Inventory.instance.Remove(Inventory.instance.equipedItem);
            Inventory.instance.UnequipItem();
            _spawner.Served();
            Destroy(gameObject); 
        }
    }

    IEnumerator BonusTimer()
    {
        while(bonusCoins > 0)
        {
            bonusCoins--;
            yield return new WaitForSecondsRealtime(1);
        }
    }

}
