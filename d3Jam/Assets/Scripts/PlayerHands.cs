using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    Collider2D _playerCollider;
    PlayerMovment _playerMovement;
    ContactFilter2D _contactFilter;
    public LayerMask objectsLayer; 
    public int gridSize;

    private List<Iinteractable> _colliderResults = new();
    
    void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
        _playerMovement = GetComponent<PlayerMovment>();

        _contactFilter.useLayerMask = true;
        _contactFilter.layerMask = objectsLayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && PlayerMovment.freePlayer)
        {
            Iinteractable interactableHit;
            var hit = Physics2D.BoxCast(transform.position, _playerCollider.bounds.size, 0, _playerMovement.Direction, gridSize, objectsLayer);
            if(hit)
            {
                hit.collider.TryGetComponent<Iinteractable>(out interactableHit);
                interactableHit.OnInteract();
            }
        }
    }
}