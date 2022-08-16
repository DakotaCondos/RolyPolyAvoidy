using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log($"Scene {sceneName} could not be found!");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void DelayLoadScene(float delayTime, string sceneName)
    {
        StartCoroutine(DelayActionLoadScene(delayTime, sceneName));
    }

    IEnumerator DelayActionLoadScene(float delayTime, string sceneName)
    {
        yield return new WaitForSeconds(delayTime);

        LoadScene(sceneName);
    }
}
