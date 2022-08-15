using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float xVelocity = 0.0f;
    [SerializeField] float yVelocity = 0.0f;
    [SerializeField] float zVelocity = 0.0f;
    [SerializeField] float moveSpeed = 0.1f;

    Vector2 rawInput;


    void Start()
    {

    }

    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        Vector2 delta = rawInput * Time.deltaTime * moveSpeed;
        Vector3 newPos = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + delta.y);
        transform.position = newPos;
        
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
