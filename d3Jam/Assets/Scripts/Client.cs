using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour, Iinteractable
{
    private Collider2D _clientCollider;
    public Item item;
    public int bonusCoins;
    public SpriteRenderer itemSprite;

    void Start()
    {
        StartCoroutine("BonusTimer");
        _clientCollider = GetComponent<Collider2D>();
        itemSprite.sprite = item.icon;
    }

    

    void Update()
    {
        
    }

    public void OnInteract()
    {
        Debug.Log("Entrou aqui!");
        if(Inventory.instance.equipedItem.name == item.name)
        {
            Inventory.instance.Remove(Inventory.instance.equipedItem);
            Inventory.instance.UnequipItem();
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
