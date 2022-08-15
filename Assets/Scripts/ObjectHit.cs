using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material collidedMaterial;
    [SerializeField] bool givesPoints;
    private bool hasGivenPoint = false;

    MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;
        if (collision.gameObject.tag == "Player" && CanGivePoint())
        {
            meshRenderer.material = collidedMaterial;
            Scorer scorer = collision.gameObject.GetComponent<Scorer>();
            scorer.ScorePoint();
            hasGivenPoint = true;
        }
    }

    private bool CanGivePoint()
    {
        return givesPoints && !hasGivenPoint;
    }
}
