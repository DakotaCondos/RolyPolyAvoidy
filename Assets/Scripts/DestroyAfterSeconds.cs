using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] public float secondsUntilDestroyed = 60;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > secondsUntilDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
