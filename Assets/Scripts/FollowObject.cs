using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] public GameObject objectToFollow;
    [SerializeField] public bool follow3D = false;
    [SerializeField] public bool rotateTowardsTarget = false;
    [SerializeField] public bool rotate3D = false;
    [SerializeField] public bool stopsOnCollision = false;
    bool hasCollided = false;
    [SerializeField] public GameObject[] objectStopsOnCollision;
    [SerializeField] public float moveSpeed = 1f;
    [SerializeField] bool stopOnLevelEnd = false;
    bool isStopped = false;
    EndLevelTrigger endLevelTrigger;

    private void Start()
    {
        endLevelTrigger = FindObjectOfType<EndLevelTrigger>();
    }

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
                if (rotate3D)
                {
                    transform.LookAt(objectToFollow.transform);
                }
                else
                {
                    Vector3 targetPos = objectToFollow.transform.position;
                    Vector3 myPos = transform.position;
                    transform.LookAt(new Vector3(targetPos.x, myPos.y, targetPos.z));
                }
            }
        }
    }

    private bool ContinueToFollow()
    {
        if (isStopped) return false;
        if (stopOnLevelEnd && endLevelTrigger != null)
        {
            if (endLevelTrigger.IsEndLevelReached())
            {
                isStopped = true;
            }

        }
            if (!stopsOnCollision) return true;
        if (hasCollided) return false;
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null || hasCollided) return;

        foreach (GameObject g in objectStopsOnCollision)
        {
            if (collision.gameObject == g)
            {
                hasCollided = true;
            }
        }
    }

    public void StopFollowing()
    {
        hasCollided = true;
    }


}
