using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject colliderObject;
    public bool isCollected = false;
    public bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (colliderObject != null && other.gameObject != colliderObject)
            return;

        isCollected = true;
        MakeInvisible();
        Trigger();
    }

    private void Trigger()
    {
        if (isTriggered) return;
        var g = gameObject.GetComponent<TriggerCondition>();
        if (g != null)
            g.TriggerConditionMet = true;
        isTriggered = true;
    }

    private void MakeInvisible()
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }
        Light[] lights = gameObject.GetComponentsInChildren<Light>();
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
}
