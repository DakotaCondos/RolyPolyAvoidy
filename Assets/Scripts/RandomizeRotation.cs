using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotation : MonoBehaviour
{
    [SerializeField] bool randomizeRotation = true;
    private float xAngle;
    private float yAngle;
    private float zAngle;

    void Start()
    {
        if (randomizeRotation)
        {
            xAngle = Random.value * 360;
            yAngle = Random.value * 360;
            zAngle = Random.value * 360;
            transform.Rotate(xAngle, yAngle, zAngle);
        }
    }

}
