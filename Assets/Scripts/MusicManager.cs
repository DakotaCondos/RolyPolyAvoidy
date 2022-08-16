using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager singleton;
    [SerializeField] AudioClip[] musicTracks;

    private void Awake()
    {
        ManageSingleton();
    }
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

    public AudioClip GetMusicTrack(int index)
    {
        return musicTracks[index];
    }
}
