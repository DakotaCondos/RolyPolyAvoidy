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
    [SerializeField] float teleportDelayTime = 2f;

    bool canTeleport = true;
    Vector2 rawInput;
    UIController uiController;

    private void Awake()
    {
        uiController = GetComponent<UIController>();
    }

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

    private void OnEscape(InputValue value)
    {
        if (uiController != null)
        {
            uiController.escapePressed();
        }
    }

    public void EnableMovement(bool value)
    {
        movementEnabled = value;
    }

    public void TeleportTo(Vector3 position)
    {
        if (canTeleport)
        {
            canTeleport = false;
            StartCoroutine(DelayTeleport(teleportDelayTime));
            transform.position = position;
        }
    }

    IEnumerator DelayTeleport(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        canTeleport = true;
    }
}
