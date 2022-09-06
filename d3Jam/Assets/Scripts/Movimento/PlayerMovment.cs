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

    private bool _moving;   //Flag para a rotina de movimentacao


    //Public fields
    

    public float walkSpeed;

    //Bolleanos de colisao
    public bool cRight, cLeft, cUp, cDown;

    //Proprierties
    public bool Moving { get {return _moving;} }
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
        TestCollisions();

        



    }

    private void TestCollisions()
    {
        if(!_moving)
        {
        if(_playerInputs.x != 0)
        {
            if(_playerInputs.x > 0)
                _movementQueue.Enqueue(Vector2.right);
            else
                _movementQueue.Enqueue(Vector2.left);
        }
        if(_playerInputs.y != 0)
        {
            if(_playerInputs.y > 0)
                _movementQueue.Enqueue(Vector2.up);
            else
                _movementQueue.Enqueue(Vector2.down);
        }
            StartCoroutine("DoMove");
        }
        

    }

    void GetherInputs()
    {
        //_playerInputs = new();

        _playerInputs.x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0); 
        _playerInputs.y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0); 

        
    }

    

    // movement coroutine
    private IEnumerator DoMove()
    {
        _moving = true;
        while(_movementQueue.Count > 0)
        {
            Vector3 pos = transform.position;
            Vector3 finish = (Vector3)_movementQueue.Dequeue() + pos;

            while (transform.position != finish)
            {
                pos = Vector3.MoveTowards(pos, finish, walkSpeed * Time.deltaTime);
                transform.position = pos;
                
                yield return new WaitForEndOfFrame();
            }

        }

        _moving = false;
    }

}

[System.Serializable]
public struct Inputs
{
    public int x, y;
}
