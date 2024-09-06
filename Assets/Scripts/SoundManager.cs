using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource MusicA, SfxA;
    public static AudioClip click, MusicSound, MenuSound;
    public AudioSource music, sfx;
    public AudioClip test, musicDefault, menuDefault;
    public static bool SFX;
    public static bool Music;
    private void Awake()
    {
        MusicA = music;
        MusicA.clip = menuDefault;
        MusicSound = musicDefault;
        MenuSound = menuDefault;
        MusicA.Play();
    }
    private void Update()
    {
        MusicA = music;
        SfxA = sfx;
        click = test;
        if(Music == false)
        {
            music.mute = true;
        }
        else
        {
            music.mute = false;
        }
    }
    public static void SFXLauncher()
    {
        if(SFX == true)
        {
            SfxA.PlayOneShot(click);
        }
    }
    public static void StartGame()
    {
        MusicA.clip = MusicSound;
        MusicA.Play();
    }
    public static void EndGame()
    {
        MusicA.clip = MenuSound;
        MusicA.Play();
    }
}
