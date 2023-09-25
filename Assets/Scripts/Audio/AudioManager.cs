using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSorce;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        //ako scena meni -> pusti meni music 
        //ako scena gameplay -> pusti gameplay music
    }

    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(musicSounds, x => x.Name == name);

        musicSource.clip = s.Clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.Name == name);

        musicSource.PlayOneShot(s.Clip);
    }

    public void MuteUnmuteMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MuteUnmuteSFX()
    {
        sfxSorce.mute = !musicSource.mute;
    }
}
