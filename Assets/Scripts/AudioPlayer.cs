using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    static AudioPlayer singleton;

    [SerializeField] float musicVolume = .5f;
    public int activeTrack = -1;
    public bool isPlayingMusic;
    MusicManager musicManager;
    AudioSource audioSource;

    private void Awake()
    {
        ManageSingleton();
        musicManager = FindObjectOfType<MusicManager>();
        audioSource = GetComponent<AudioSource>();
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

    public void PlaySound(AudioClip sound, float volume)
    {
        if (sound is not null)
        {
            audioSource.PlayOneShot(sound, volume);
        }
    }

    public void PlayMusicTrack(int index)
    {

        AudioClip track = musicManager.GetMusicTrack(index);
        if (track != null)
        {
            if (activeTrack != index)
            {
                audioSource.clip = track;
                audioSource.volume = musicVolume;
                audioSource.Play();
                isPlayingMusic = true;
                activeTrack = index;
            }
        }
    }

    public void StopAudio()
    {
        Debug.Log("Stop Audio Called");
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
            isPlayingMusic = false;
        }
    }
}