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
    private SpriteRenderer _timerSprite;
    public Item item;
    float timer;
    float fullTimer;
    
    public Vector3 dir;

    bool move = true;

    SpawnerScript _spawner;

    GameObject want;

    int coins;

    AudioSource audioSource;
    public AudioClip arriveSound, deliverySound, wrongSound;

    void Start()
    {
        timer = item.time;
        fullTimer = timer;
        coins = item.coins;

        
        _clientCollider = GetComponent<Collider2D>();

        _animator = GetComponentInChildren<Animator>();

        _bubbleSprite = GetComponentsInChildren<SpriteRenderer>()[1];
        _wantSprite = GetComponentsInChildren<SpriteRenderer>()[2];
        _timerSprite = GetComponentsInChildren<SpriteRenderer>()[3];

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
        //GetComponentsInChildren<Transform>()[2].transform.rotation = Quaternion.identity;

        _spawner = GameObject.Find("ClientSpawner").GetComponent<SpawnerScript>();

        _bubbleSprite.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    

    void Update()
    {
        if(!move) return;

        transform.Translate(dir * Time.deltaTime, Space.World);

        if(Physics2D.OverlapBox(transform.position, Vector3.one, 0, 1 << 6))
        {
            transform.Translate((dir * 0.2f), Space.World);
            move = false;
            AnimateWant();
            StartCoroutine(nameof(Timer));
        }


    }

    private void AnimateWant()
    {
        _bubbleSprite.gameObject.SetActive(true);

        _animator.Play("SpeachBubbleAnimation");
        audioSource.PlayOneShot(arriveSound);
    }

    public void OnInteract()
    {

        if(Inventory.instance.equipedItem)
        {
            if(Inventory.instance.equipedItem.itemName == item.itemName && (Inventory.instance.equipedItem.id == itemType.planta || Inventory.instance.equipedItem.id == itemType.animal))
            {
                audioSource.PlayOneShot(deliverySound);
                _spawner.Served(this);
                
            }
            else
            {
                _spawner.WrongServed(this);
            }

            Inventory.instance.Remove(Inventory.instance.equipedItem);
            Inventory.instance.UnequipItem();
            Destroy(gameObject, 1);
        }
    }

    public int GetResultCoins()
    {
        return (int)(coins + ((timer / fullTimer) * coins));
    }

    IEnumerator Timer()
    {
        while(timer > 0)
        {
            timer -= Time.deltaTime * DataManager.instance.paciencia;

            _timerSprite.color = Color.Lerp(Color.red, Color.green, timer / fullTimer);
            _timerSprite.transform.localScale = new(1.2f * (timer/fullTimer), 0.15f, 0);

            yield return new WaitForEndOfFrame();
        }

        _spawner.WrongServed(this);
        Destroy(gameObject, 1);
    }

}
