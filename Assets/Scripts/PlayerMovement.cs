using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float xVelocityMultiplier = 1f;
    [SerializeField] float yVelocityMultiplier = 1f;
    [SerializeField] float zVelocityMultiplier = 1f;
    [SerializeField] float moveSpeed = 1f;

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
        Vector3 newPos = new Vector3(
            (transform.position.x + delta.x) * xVelocityMultiplier,
            transform.position.y,
            (transform.position.z + delta.y) * zVelocityMultiplier);
        transform.position = newPos;

    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
