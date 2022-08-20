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
            string yourScoreRating = "";

            switch (score)
            {
                case 0:
                    yourScoreRating = "Perfect!";
                    break;
                case 1:
                    yourScoreRating = "So close! Great job!";
                    break;
                case 2:
                    yourScoreRating = "Excellent!";
                    break;
                case 3:
                    yourScoreRating = "An Average run.";
                    break;
                case 4:
                    yourScoreRating = "Not quite!";
                    break;
                case 5:
                    yourScoreRating = "Try a little harder next time!";
                    break;
                default:
                    yourScoreRating = "Were you even trying?";
                    break;
            }
            uiController.DisplayLevelEnd(text + yourScoreRating);
        }
    }
}
