using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    PlayerMovement playerMovement;
    UIController uiController;
    Scorer scorer;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        uiController = FindObjectOfType<UIController>();
        scorer = FindObjectOfType<Scorer>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        if (other.tag == "Player")
        {
            playerMovement.EnableMovement(false);
            uiController.endLevel();
            int score = scorer.GetPoints();
            string text = $"Things touched: {score}\n";
            uiController.DisplayLevelEnd(text + GetLevelPerformaceMessage(score));
        }
    }

    private string GetLevelPerformaceMessage(int score)
    {
        string message = score switch
        {
            int i when i == 0 => "Perfect!",
            int i when i == 1 => "So close! Great job!",
            int i when i == 2 => "Excellent!",
            int i when i == 3 => "An Average run.",
            int i when i == 4 => "Not quite!",
            int i when i == 5 => "Try a little harder next time!",
            int i when i > 5 && i <= 19 => "Were you even trying?",
            _ => "Genuinely impressive..."
        };

        return message;
    }
}
