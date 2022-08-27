using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbProjectile : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public float moveSpeed = 3;
    [SerializeField] public bool destroyOnCollision = true;
    [SerializeField] public float destroyDelay = .5f;
    bool hasCollided = false;
    Vector3 targetPosition;

    private void Start()
    {
        targetPosition = target.transform.position;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (target == null || hasCollided) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
        Destroy(gameObject, destroyDelay);
    }
}
