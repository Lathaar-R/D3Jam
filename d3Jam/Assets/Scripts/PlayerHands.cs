using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    PlayerMovment _playerMoveScript;

    public EquippableItens equippedItem;
    
    void Start()
    {
        _playerMoveScript = GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(_playerMoveScript.Direction);
            Iinteractble intectbleHit;
            
            var hit = Physics2D.Raycast(transform.position, _playerMoveScript.Direction, 1,  1 << 7);
            //Debug.Log(~gameObject.layer);
            if(hit)
            {
                if(hit.collider.TryGetComponent<Iinteractble>(out intectbleHit))
                {
                    intectbleHit.OnClick(this);
                }
                //Debug.Log(_playerMoveScript.Direction);
                
            }
        }
    }
}

public enum EquippableItens
{
    NONE,
    luz,
    agua
}
