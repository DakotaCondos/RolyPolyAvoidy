using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] int levelPointsCurrent = 0;


    public void ScorePoint()
    {
        levelPointsCurrent++;
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
