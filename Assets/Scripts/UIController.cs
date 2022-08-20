using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject topPanel;
    [SerializeField] TextMeshProUGUI topPanelText;
    [SerializeField] GameObject centerPanel;
    [SerializeField] TextMeshProUGUI centerPanelText;
    [SerializeField] GameObject centerPanelEscape;
    [SerializeField] float initailMessageDisplayTime = 5;
    [SerializeField] bool endLevelReached = false;
    [SerializeField] bool initailMessageDisplay = false;
    [SerializeField] string initailMessageText = "";


    void Start()
    {
        topPanel.SetActive(false);
        centerPanel.SetActive(false);
        centerPanelEscape.SetActive(false);
        DisplayInitialMessage();
    }

    private void DisplayInitialMessage()
    {
        if (initailMessageDisplay)
            FlashMessageTopDisplay(initailMessageText);
    }

    void Update()
    {

    }

    public void FlashMessageTopDisplay(string text)
    {
        StartCoroutine(displayForSetTimeTop(text));
    }

    public void escapePressed()
    {
        if (endLevelReached) return;
        if (centerPanelEscape.activeInHierarchy)
        {
            centerPanelEscape.SetActive(false);
        }
        else
        {
            centerPanelEscape.SetActive(true);
        }

    }
    public void endLevel()
    {
        endLevelReached = true;
    }

    IEnumerator displayForSetTimeTop(string text)
    {
        topPanel.SetActive(true);
        topPanelText.text = text;
        yield return new WaitForSeconds(initailMessageDisplayTime);
        topPanel.SetActive(false);
    }


    public void DisplayLevelEnd(string text)
    {
        centerPanelText.text = text;
        centerPanel.SetActive(true);

    }
}
