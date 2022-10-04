using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public int radius;
    Collider2D _lightCollider;
    public GameObject luz;
    [SerializeField] LayerMask playerLayer;

    private void Start()
    {
        _lightCollider = GetComponent<Collider2D>();

        luz.transform.localScale *= DataManager.instance.lightR;
        
    }
    void Update()
    {
        
    }

    public void PickLantern()
    {
        
        transform.SetParent(Inventory.instance.gameObject.transform);
        transform.localPosition = Vector3.zero;
    }

    public void DropLantern()
    {
        
        transform.SetParent(null);
        transform.localPosition = Vector3Int.RoundToInt(Inventory.instance.gameObject.transform.position);
 
    }
}
