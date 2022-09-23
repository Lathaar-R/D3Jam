using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    #region Variables
    //Private Fields
    private Queue<Vector2> _movementQueue = new();
    //private Vector2 _gridDisplacment = new(0.5f, 0.5f);
    private Vector3Int _gridPos = Vector3Int.zero;
    [SerializeField] private float gridSize = 1;
    [SerializeField] private Vector2 _playerInputs;

    [SerializeField] private Collider2D _playerCollider;    //Player Collider

    private bool _moving;   //Flag para a rotina de movimentacao
    Collider2D[] results = new Collider2D[3];


    //Public fields
    

    public float walkSpeed;
    public LayerMask groundLayer;

    //Bolleanos de colisao
    //public bool cRight, cLeft, cUp, cDown;

    //Proprierties
    public bool Moving { get {return _moving;} }
    public bool Movement{
        get 
        {
            return _moving || _playerInputs.sqrMagnitude > 0;
        }
        private set
        {

        }
        }
    public Vector3 Direction{get; private set;}
    #endregion

    public static bool freePlayer = true;
    
    void Start()
    {
        //Ajust initial pos
        _gridPos = Vector3Int.RoundToInt(transform.position);
        transform.position = _gridPos;

        _playerCollider = GetComponent<Collider2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMovment.freePlayer) return;
        //Pegar Inputs do jogador
        GetherInputs();

        //Testar colisao com paredes
        TestCollisions();

        //Movendo personagem
        Move();
        

        //Debug.Log(Direction);
        //if(Input.GetKeyDown(KeyCode.Space)) Inventory.instance.;

    }

    private void Move()
    {
        if(!Moving)
        {
            if(_playerInputs.x > 0)
            {
                _movementQueue.Enqueue(Vector2.right * gridSize);
            }
            else if(_playerInputs.x < 0)
            { 
                _movementQueue.Enqueue(Vector2.left * gridSize);
            }
            if(_playerInputs.y > 0)
            {
                _movementQueue.Enqueue(Vector2.up * gridSize);
            }
            else if(_playerInputs.y < 0)
            {
                _movementQueue.Enqueue(Vector2.down * gridSize);
            }
            StartCoroutine("DoMove");
        }
    }

    private void TestCollisions()
    {
        if(!_moving)
        {
            if(_playerInputs.x != 0)
            {
                if(Physics2D.OverlapBox(transform.position + (Vector3.right * _playerInputs.x), _playerCollider.bounds.size, 0, groundLayer))
                {
                    _playerInputs.x = 0;
                }
            }
            if(_playerInputs.y != 0)
            {
                if(Physics2D.OverlapBox(transform.position + (Vector3.up * _playerInputs.y), _playerCollider.bounds.size, 0, groundLayer))
                {
                    _playerInputs.y = 0;
                }
            }
            
        }
        

    }

    void GetherInputs()
    {
        //_playerInputs = new();

        _playerInputs.x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0); 
        _playerInputs.y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0); 

        if(_playerInputs.sqrMagnitude != 0)
            Direction = _playerInputs;  
        
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

