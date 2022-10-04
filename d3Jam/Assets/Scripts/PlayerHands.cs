using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    Collider2D _playerCollider;
    PlayerMovment _playerMovement;
    public LayerMask objectsLayer; 
    public LayerMask grabLayer; 
    public int gridSize;
    


    private List<Iinteractable> _colliderResults = new();
    
    void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
        _playerMovement = GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.K) && PlayerMovment.freePlayer)
        // {
        //     if(Inventory.instance.equipedItem.id == itemType.pegavel)
        //     {
        //         Inventory.instance.UnequipItem();
                
        //         Inventory.instance.grabItem.Drop(_playerMovement.transform.position + _playerMovement.Direction);
        //     }
        // } 

        if(Input.GetKeyDown(KeyCode.Space) && PlayerMovment.freePlayer)
        {
            // var hit = Physics2D.BoxCast(transform.position, _playerCollider.bounds.size, 0, _playerMovement.Direction, gridSize, grabLayer);
            // if(hit)
            // {
            //     if(Inventory.instance.equipedItem && Inventory.instance.equipedItem.id == itemType.pegavel)
            //         return;
                
                
            //     hit.collider.TryGetComponent<Igrabbable>(out Inventory.instance.grabItem);
            //     Inventory.instance.grabItem?.OnInteract();
                
            //     return;
            // }

            

            
            var hit = Physics2D.BoxCast(transform.position, _playerCollider.bounds.size, 0, _playerMovement.Direction, gridSize, objectsLayer);
            if(hit)
            {
                Debug.Log(hit.collider.name);
                if(hit.collider.tag.Equals("Light"))
                {
                    if(hit.transform.parent == null)
                        hit.collider.GetComponent<LightScript>().PickLantern();
                    else
                        hit.collider.GetComponent<LightScript>().DropLantern();
                } 
                else
                {       
                    Iinteractable interactableHit;
                    hit.collider.TryGetComponent<Iinteractable>(out interactableHit);
                    interactableHit?.OnInteract();
                }
            }
        }
    }
}