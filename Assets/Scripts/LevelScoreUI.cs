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

    private void Awake()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }
    void Start()
    {
        LevelNumberTMP.text = "Level " + LevelNumber;
        LevelScoreTMP.text = scoreboard.GetLevelScore(LevelNumber);
    }
}
