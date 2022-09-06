using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovment : MonoBehaviour
{
    #region Variables
    //Private Fields
    private Queue<Vector2> _movementQueue = new();
    private Vector2 _gridDisplacment = new(0.5f, 0.5f);
    private Vector2Int _gridPos = Vector2Int.zero;
    [SerializeField] private Inputs _playerInputs;

    [SerializeField] private Collider2D _playerCollider;    //Player Collider


    //Public fields
    //Bolleanos de colisao
    public bool cRight, cLeft, cUp, cDown, moving;
    #endregion

    
    void Start()
    {
        //Ajust initial pos
        _gridPos = Vector2Int.RoundToInt(transform.position);
        transform.position = _gridPos + _gridDisplacment;

        _playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pegar Inputs do jogador
        GetherInputs();

        //Testar colisao com paredes
        //TestCollisions();

        



    }

    private void TestCollisions()
    {
        if(_playerInputs.x != 0)
        {
            var pos = transform.position;
            //var hit = Physics2D.Raycast(transform.position, )
        }
    }

    void GetherInputs()
    {
        //_playerInputs = new();

        _playerInputs.x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0); 
        _playerInputs.y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0); 

        
    }

    

    // movement coroutine
    // private IEnumerator DoMove()
    // {
    //     while(_movementQueue.Count > 0)
    //     {

    //     }
    // }

}

[System.Serializable]
public struct Inputs
{
    public int x, y;
}
