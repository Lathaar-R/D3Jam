using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _playerAnimator;
    PlayerMovment _movementScript;
    SpriteRenderer _playerSpriteRenderer;
    string _currentState;
    void Start()
    {
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();

        _movementScript = GetComponent<PlayerMovment>();

        _playerAnimator = GetComponent<Animator>();
        _currentState = "Idle";

        ChangeAnimation(_currentState);
    }

    
    void Update()
    {
        if(_movementScript.Movement.x < 0)
        {
            _playerSpriteRenderer.flipX = true;
        }
        else if(_movementScript.Movement.x > 0)
        {
            _playerSpriteRenderer.flipX = false;
        }
    }

    void ChangeAnimation(string newState)
    {
        //Check id animation is already been played
        if(_currentState == newState) return;

        //Play the new animation
        _playerAnimator.Play(newState);

        //Update the current state
        _currentState = newState;
    }
}
