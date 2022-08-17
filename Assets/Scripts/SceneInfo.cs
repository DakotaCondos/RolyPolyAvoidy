using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    [SerializeField] string currentScene;
    [SerializeField] string nextScene;
    [SerializeField] string mainMenuSceneName = "Main Menu";
    [SerializeField] int musicIndex = -1;
    [SerializeField] bool playMusic = false;


    private void Start()
    {
        PlayMusic();
    }
    public string GetCurrentScene() { return currentScene; }
    public string GetNextScene() { return nextScene; }

    public void LoadNextLevel()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.LoadScene(nextScene);
        }
    }

    public void ReloadLevel()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.LoadScene(currentScene);
        }
    }

    public void LoadMainMenu()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.LoadScene(mainMenuSceneName);
        }
    }

    public void QuitGame()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.QuitGame();
        }
    }

    private void PlayMusic()
    {
        if (playMusic && musicIndex >= 0)
        {
            AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
            if (audioPlayer != null)
            {
                audioPlayer.PlayMusicTrack(musicIndex);
            }
        }
    }

}
