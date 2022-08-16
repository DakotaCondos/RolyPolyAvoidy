using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float enableDelay = 5f;
    MeshRenderer meshRenderer;
    Rigidbody body;
    float startTime;

    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        meshRenderer = GetComponent<MeshRenderer>();
        body = GetComponent<Rigidbody>();
        meshRenderer.enabled = false;
        body.useGravity = false;
    }

    void Update()
    {
        EnableAfterDelay();
    }

    private void EnableAfterDelay()
    {
        if (Time.realtimeSinceStartup - startTime > enableDelay)
        {
            meshRenderer.enabled = true;
            body.useGravity = true;
        }
    }
}
