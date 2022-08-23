using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] bool follow3D = false;
    [SerializeField] bool rotateTowardsTarget = false;
    [SerializeField] bool stopsOnCollision = false;
    bool hasCollided = false;
    [SerializeField] GameObject objectStopsOnCollision;
    [SerializeField] float moveSpeed = 1f;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (objectToFollow != null && ContinueToFollow())
        {
            if (follow3D)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, objectToFollow.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 targetPosition = objectToFollow.transform.position;
                transform.position = Vector3.MoveTowards(
                    transform.position, new Vector3(targetPosition.x, transform.position.y, targetPosition.z), moveSpeed * Time.deltaTime);
            }

            if (rotateTowardsTarget)
            {
                transform.LookAt(objectToFollow.transform);
            }
        }
    }

    private bool ContinueToFollow()
    {
        if (!stopsOnCollision) return true;
        if (hasCollided) return false;
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objectStopsOnCollision)
        {
            hasCollided = true;
        }
    }

    public void StopFollowing()
    {
        hasCollided = true;
    }


}
