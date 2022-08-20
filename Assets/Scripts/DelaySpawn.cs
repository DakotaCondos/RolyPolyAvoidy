using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySpawn : MonoBehaviour
{
    [SerializeField] float enableDelay = 5f;
    MeshRenderer meshRenderer;
    Collider colliderBody;
    float startTime;

    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        meshRenderer = GetComponent<MeshRenderer>();
        colliderBody = GetComponent<Collider>();
        meshRenderer.enabled = false;
        colliderBody.enabled = false;
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
            colliderBody.enabled = true;
        }
    }
}
