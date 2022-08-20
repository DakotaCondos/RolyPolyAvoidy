using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] int howManyToSpawn = 10;
    [SerializeField] float spawnPerSecond = 10;

    void Start()
    {
        StartCoroutine(SpawnBall(howManyToSpawn));
    }


    IEnumerator SpawnBall(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(ball, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1 / spawnPerSecond);
        }
    }
}
