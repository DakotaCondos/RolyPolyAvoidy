using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Vector3 playerObjectStartPos;
    public Vector3 outOfBoundsResetPosition;

    private void Start()
    {
        playerObjectStartPos = FindObjectOfType<PlayerMovement>().gameObject.transform.position;

        if (playerObjectStartPos != null)
        {
            outOfBoundsResetPosition = new(playerObjectStartPos.x, playerObjectStartPos.y, playerObjectStartPos.z);
        }
        else
        {
            Debug.LogWarning("playerStartPos is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other == null) return;
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().TeleportTo(outOfBoundsResetPosition);
        }
    }
}
