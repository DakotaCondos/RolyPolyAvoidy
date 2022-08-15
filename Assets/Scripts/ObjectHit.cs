using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material collidedMaterial;

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
        if (collision.gameObject.tag == "Player")
        {
            meshRenderer.material = collidedMaterial;
        }
    }
}
