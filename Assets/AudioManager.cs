using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;

    [Header ("AUDIO clip")]
    public AudioClip jump;
    public AudioClip background;
    public AudioClip collectible;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
} 
