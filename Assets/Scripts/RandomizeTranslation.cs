using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTranslation : MonoBehaviour
{
    [SerializeField] bool randomizationTranslation = true;
    [SerializeField] float minDistance = 1;
    [SerializeField] float maxDistance = 3;
    void Awake()
    {
        if (randomizationTranslation)
        {
            float randomDistance = UnityEngine.Random.Range(minDistance, maxDistance);
            transform.position += new Vector3(randomDistance, 0, 0);
        }
    }
}
