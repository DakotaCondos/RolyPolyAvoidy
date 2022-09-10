using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    static Scoreboard singleton;
    int totalLevels = 30;
    private int[] scores;
    [SerializeField] bool useDevValue;
    [SerializeField] int devValue = 0;
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
        int initialValue = -1;
        if (useDevValue)
            initialValue = devValue;

        // level 0 is ignored as a tutorial level
        scores = new int[totalLevels + 1];
        for (int i = 1; i < scores.Length; i++)
        {
            scores[i] = initialValue;
        }
    }

    public void UpdateLevelScore(int level, int score)
    {
        if (0 < level && level <= totalLevels)
        {
            if (score < scores[level] || scores[level] == -1)
                scores[level] = score;
        }
    }

    public string GetLevelScore(int level)
    {
        if (0 < level && level <= totalLevels)
        {
            int score = scores[level];
            if (score != -1) return score.ToString();
            else return "N/A";
        }
        else return "Not A valid Level";
    }
    public bool AreAllLevelsCompleted()
    {
        bool hasCompletedAllLevels = true;
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == -1) hasCompletedAllLevels = false;
        }
        return hasCompletedAllLevels;
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
            if (totalScore == 0)
            {
                return "Perfect across all levels!\nYou are the best!";
            }

            return totalScore.ToString() + "\nGreat job! Aim for a prefect score.";
        }
        else return "Complete all levels to see your score!";

    }

}
