using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float moveSpeed = 1.5f;
    public bool isSlideEnabled = true;

    int currentIndex = 0;
    Transform targetPosition;

    private void Start()
    {
        targetPosition = points[currentIndex];
    }
    private void Update()
    {
        MovementLoop();
    }

    private void MovementLoop()
    {
        if (!isSlideEnabled) return;

        if (!IsCloseEnough())
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            if (currentIndex + 1 < points.Length)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            targetPosition = points[currentIndex];
        }
    }

    private bool IsCloseEnough()
    {
        Vector3 current = transform.position;
        Vector3 offset = current - targetPosition.position;
        return offset.magnitude < 0.01;
    }

}
