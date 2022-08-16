using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float xVelocityMultiplier = 1f;
    //[SerializeField] float yVelocityMultiplier = 1f; comment out until used
    [SerializeField] float zVelocityMultiplier = 1f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool movementEnabled = true;

    Vector2 rawInput;

    void Update()
    {
        Move();

    }

    private void Move()
    {
        if (!movementEnabled) return;
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

    public void EnableMovement(bool value)
    {
        movementEnabled = value;
    }
}
