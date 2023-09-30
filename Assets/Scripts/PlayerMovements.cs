using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float _movementSpeed = 1;
    private Rigidbody2D _playerRb2D;
    private InputAction _onMoveAction;
    private Vector2 _moveAction;

    void Start(){
        _playerRb2D = GetComponent<Rigidbody2D>();
        PlayerInput _playerInput = GetComponent<PlayerInput>();
        _onMoveAction = _playerInput.actions.FindAction("Move");
    }

    void FixedUpdate(){
        ReadValues();
        UpdateMovements();
    }
    void ReadValues(){
        _moveAction = _onMoveAction.ReadValue<Vector2>();
    }
    void UpdateMovements(){
        _playerRb2D.velocity = new Vector2(_moveAction.x * _movementSpeed, _moveAction.y * _movementSpeed);
    }
    
}
