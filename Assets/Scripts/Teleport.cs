using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Teleport teleportDestination;
    Vector3 position;

    void Start()
    {
        position = transform.position + new Vector3(0, .75f, 0);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().TeleportTo(teleportDestination.position);
        }
    }
}
