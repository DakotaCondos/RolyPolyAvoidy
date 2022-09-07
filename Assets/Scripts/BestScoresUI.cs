using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoresUI : MonoBehaviour
{
    TextMeshProUGUI bestScores;
    Scoreboard scoreboard;

    private void Awake()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        bestScores = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        bestScores.text = "Best Scores: " + scoreboard.GetTotalScore();
    }


}
