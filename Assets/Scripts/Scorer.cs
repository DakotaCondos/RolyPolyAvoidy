using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    //[SerializeField] int levelPointsMax = 1;
    //[SerializeField] int levelPointsMin = 1; comment out until used
    [SerializeField] int levelPointsCurrent = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    public void ScorePoint()
    {
        levelPointsCurrent++;
        print($"Point added! Total points: {levelPointsCurrent}");
    }

    public void resetPoints()
    {
        levelPointsCurrent = 0;
    }
    public int GetPoints()
    {
        return levelPointsCurrent;
    }
}
