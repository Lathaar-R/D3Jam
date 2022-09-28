using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour, Iinteractable
{
    Animator _animator;
    private Collider2D _clientCollider;
    private SpriteRenderer _wantSprite;
    private SpriteRenderer _bubbleSprite;
    public Item item;
    public int bonusCoins;
    public Vector3 dir;

    bool move = true;

    SpawnerScript _spawner;

    GameObject want;

    public int coins;

    void Start()
    {
        StartCoroutine("BonusTimer");
        _clientCollider = GetComponent<Collider2D>();

        _animator = GetComponentInChildren<Animator>();

        _bubbleSprite = GetComponentsInChildren<SpriteRenderer>()[1];
        _wantSprite = GetComponentsInChildren<SpriteRenderer>()[2];
        _wantSprite.sprite = item.icon;
        //_wantSprite.gameObject.transform.forward = dir;
        if(dir == Vector3.left) 
        {
            _bubbleSprite.flipX = true;
            _bubbleSprite.transform.localPosition += Vector3.left * 2;
        }
        if(dir == Vector3.down)
        {
            _bubbleSprite.flipY = true;
            _bubbleSprite.transform.localPosition += Vector3.down * 2;
        }
        GetComponentsInChildren<Transform>()[2].transform.rotation = Quaternion.identity;

        _spawner = GameObject.Find("ClientSpawner").GetComponent<SpawnerScript>();

        _bubbleSprite.gameObject.SetActive(false);
    }

    

    void Update()
    {
        if(!move) return;

        transform.Translate(dir * Time.deltaTime, Space.World);

        if(Physics2D.OverlapBox(transform.position, Vector3.one, 0, 1 << 6))
        {
            transform.Translate(-(dir * Time.deltaTime), Space.World);
            move = false;
            AnimateWant();
        }

    }

    private void AnimateWant()
    {
        _bubbleSprite.gameObject.SetActive(true);

        _animator.Play("SpeachBubbleAnimation");
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
