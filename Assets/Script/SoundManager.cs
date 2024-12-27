using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource backgroundAudioSource;
    public AudioSource soundFXAudioSource;
    public AudioClip levelCompleteAudio;
    public AudioClip gameOverAudio;
    public AudioClip buttonClick;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundAudioSource != null && backgroundAudioSource.clip != null && !backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Play();
        }
    }

    public void PlayLevelCompleteAudio()
    {
        if (soundFXAudioSource != null && levelCompleteAudio != null)
        {
            soundFXAudioSource.PlayOneShot(levelCompleteAudio);
        }
    }

    public void PlayGameOverAudio()
    {
        if (soundFXAudioSource != null && gameOverAudio != null)
        {
            soundFXAudioSource.PlayOneShot(gameOverAudio);
        }
    }

    public void PlayButtonClickAudio()
    {
        if (soundFXAudioSource != null && buttonClick != null)
        {
            soundFXAudioSource.PlayOneShot(buttonClick);
        }
    }

    public void DestroySoundManager()
    {
        Destroy(gameObject);
    }
}
