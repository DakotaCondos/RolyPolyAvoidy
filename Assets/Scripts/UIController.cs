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
    [SerializeField] float displayTime = 5;


    void Start()
    {
        centerPanel.SetActive(false);
        FlashMessageTopDisplay("Get to the finish and dont touch anything!");
    }

    void Update()
    {

    }

    public void FlashMessageTopDisplay(string text)
    {
        StartCoroutine(displayForSetTimeTop(text));
    }

    IEnumerator displayForSetTimeTop(string text)
    {
        topPanel.SetActive(true);
        topPanelText.text = text;
        yield return new WaitForSeconds(displayTime);
        topPanel.SetActive(false);
    }


    public void DisplayLevelEnd(string text)
    {
        centerPanelText.text = text;
        centerPanel.SetActive(true);

    }
}
