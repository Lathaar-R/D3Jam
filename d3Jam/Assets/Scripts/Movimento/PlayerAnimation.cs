using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _playerAnimator;
    PlayerMovment _movementScript;
    SpriteRenderer _playerSpriteRenderer;
    string _currentState;

    public List<string> animations; 
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
        if(_movementScript.Direction.x < 0)
        {
            _playerSpriteRenderer.flipX = true;
        }
        else if(_movementScript.Direction.x > 0)
        {
            _playerSpriteRenderer.flipX = false;
        }

        if(_movementScript.Movement)
        {
            _playerAnimator.SetInteger("Speed", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Speed", 0);
        }
    }

    void ChangeAnimation(string newState)
    {
        //Check if animation is already been played
        if(_currentState == newState) return;

        //Play the new animation
        _playerAnimator.Play(newState);

        //Update the current state
        _currentState = newState;
        Debug.Log("Change");
    }

}
