using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    PlayerMovment _playerMoveScript;
    
    void Start()
    {
        _playerMoveScript = GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Iinteractble intectbleHit;
            
            var hit = Physics2D.Raycast(transform.position, _playerMoveScript.Direction, 1,  1 << 7);
            if(hit)
            {
                if(hit.collider.TryGetComponent<Iinteractble>(out intectbleHit))
                {
                    intectbleHit.OnClick();
                }
                
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
