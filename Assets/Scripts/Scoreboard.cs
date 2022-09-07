using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    static Scoreboard singleton;
    private int[] scores = new int[31];
    int totalLevels = 31;
    private void ManageSingleton()
    {
        if (singleton != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        ManageSingleton();
    }
    private void Start()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = -1;
        }
    }

    public void UpdateLevelScore(int level, int score)
    {
        if (0 < level && level < totalLevels - 1)
        {
            scores[level] = score;
        }
    }

    public string GetLevelScore(int level)
    {
        if (0 < level && level < totalLevels - 1)
        {
            int score = scores[level];
            if (score != -1) return score.ToString();
            else return "N/A";
        }
        else return "Not A valid Level";
    }

    public string GetTotalScore()
    {
        bool hasCompletedAllLevels = true;
        int totalScore = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == -1) hasCompletedAllLevels = false;
            totalScore += scores[i];
        }
        if (hasCompletedAllLevels)
        {
            return totalScore.ToString();
        }
        else return "Complete all levels to see your score!";

    }

}
