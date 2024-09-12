using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound{
    BUTTON_CLICK,
    ADD_SCORE,
    ADD_TURN,
    GAME_END,
    BGM,
    FLIP_CARD,

}
[System.Serializable]
public struct SoundClips{
    public Sound Sound;
    public AudioClip AudioClip;
    [Range(0, 1)] public float SoundVolume;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get;private set;}
    [SerializeField]private AudioSource sfxAudioSource;
    [SerializeField]private AudioSource bgmAudioSource;
    [SerializeField] private SoundClips[] soundClips;

    private void Awake()
    {
        if(Instance==null){
            Instance = this;
        }
    }

    private SoundClips GetAudioClip(Sound sound)
    {
        foreach (var soundClip in soundClips)
        {
            if (soundClip.Sound == sound)
            {
                return soundClip;
            }
        }

        return default(SoundClips);
    }
    private void Play(AudioSource audioSource, Sound sound)
    {

        var soundClip = GetAudioClip(sound);
        audioSource.clip = soundClip.AudioClip;
        audioSource.volume = soundClip.SoundVolume;
        audioSource.Play();
       
    }
    public void PlaySFX(Sound sfx){
         sfxAudioSource.loop = false;
        Play(sfxAudioSource,sfx);
    }
    public void PlayBGM(Sound bgm)
    {
        bgmAudioSource.loop = true;
        Play(bgmAudioSource, bgm);
    }   
}
