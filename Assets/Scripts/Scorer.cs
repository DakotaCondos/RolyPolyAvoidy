using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] int levelPointsCurrent = 0;
    private bool isActive = true;
    EndLevelTrigger endLevelTrigger;

    private void Awake()
    {
        endLevelTrigger = FindObjectOfType<EndLevelTrigger>();
    }

    void Update()
    {
        if (endLevelTrigger != null)
        {
            if (endLevelTrigger.IsEndLevelReached())
            {
                isActive = false;
            }
        }
    }


    public void ScorePoint()
    {
        if (isActive)
        {
            levelPointsCurrent++;
        }
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
