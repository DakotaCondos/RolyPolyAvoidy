using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] int levelPointsCurrent = 0;
    private bool isActive = true;
    EndLevelTrigger endLevelTrigger;
    Scoreboard scoreboard;
    SceneInfo sceneInfo;

    private void Awake()
    {
        endLevelTrigger = FindObjectOfType<EndLevelTrigger>();
        scoreboard = FindObjectOfType<Scoreboard>();
        sceneInfo = FindObjectOfType<SceneInfo>();
    }

    void Update()
    {
        if (endLevelTrigger != null)
        {
            if (endLevelTrigger.IsEndLevelReached())
            {
                if (isActive)
                {
                    scoreboard.UpdateLevelScore(sceneInfo.levelnumber, levelPointsCurrent);
                }
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
