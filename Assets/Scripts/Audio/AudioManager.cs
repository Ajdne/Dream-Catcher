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
        musicSource.pitch = 1;
    }
    private void OnEnable()
    {
        EventManager.SFXEvent += PlaySFX;
        EventManager.MusicEvent += PlayMusic;
        EventManager.SpeedUpMusicEvent += SpeedUpMusic;
    }
    private void OnDisable()
    {
        EventManager.SFXEvent -= PlaySFX;
        EventManager.MusicEvent -= PlayMusic;
        EventManager.SpeedUpMusicEvent -= SpeedUpMusic;
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

        sfxSorce.PlayOneShot(s.Clip);
    }

    public void MuteUnmuteMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MuteUnmuteSFX()
    {
        sfxSorce.mute = !musicSource.mute;
    }
    public void SpeedUpMusic()
    {
        if(musicSource.pitch <= 2)
            musicSource.pitch += 0.01f;
    }
}
