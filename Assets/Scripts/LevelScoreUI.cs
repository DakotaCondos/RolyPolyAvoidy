using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LevelNumberTMP;
    [SerializeField] TextMeshProUGUI LevelScoreTMP;
    [SerializeField] int LevelNumber;
    Scoreboard scoreboard;
    LevelManager levelManager;

    private void Awake()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {
        LevelNumberTMP.text = "Level " + LevelNumber;
        string scoreText = scoreboard.GetLevelScore(LevelNumber);
        if (scoreText == "0")
        {
            scoreText = "Perfect";
        }
        else if (scoreText != "N/A")
        {
            scoreText = "+" + scoreText;
        }
        LevelScoreTMP.text = scoreText;
    }

    public void LoadAssociatedLevel()
    {
        if (levelManager != null) levelManager.LoadScene("Level" + LevelNumber);
    }
}
