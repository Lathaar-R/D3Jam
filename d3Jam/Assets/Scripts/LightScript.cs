using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public int radius;
    Collider2D _lightCollider;

    private void Start()
    {
        _lightCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && PlayerMovment.freePlayer)
        {
            if(Physics2D.OverlapBox(transform.position, _lightCollider.bounds.size, 0, LayerMask.NameToLayer("Player")))
            {
                if(transform.parent == null)
                    PickLantern();
                else
                    DropLantern();
            }
            
        }
    }

    private void PickLantern()
    {
        
        transform.SetParent(Inventory.instance.gameObject.transform);
        transform.localPosition = Vector3.zero;
    }

    private void DropLantern()
    {
        
        transform.SetParent(null);
        transform.localPosition = Vector3Int.RoundToInt(Inventory.instance.gameObject.transform.position);
 
    }
}
