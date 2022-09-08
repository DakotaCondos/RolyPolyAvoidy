using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] int howManyToSpawn = 10;
    [SerializeField] float spawnPerSecond = 10;
    [SerializeField] GameObject followTarget;

    void Start()
    {
        StartCoroutine(SpawnBall(howManyToSpawn));
    }


    IEnumerator SpawnBall(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);
            if (followTarget != null)
            {
                FollowObject f = newBall.GetComponent<FollowObject>();
                FollowObject m = gameObject.GetComponent<FollowObject>();
                if (f != null)
                {
                    f.objectToFollow = followTarget;
                    if (m != null)
                    {
                        m.moveSpeed = f.moveSpeed;
                    }
                }
            }
            yield return new WaitForSeconds(1 / spawnPerSecond);
        }
    }
}
