using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;


    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
