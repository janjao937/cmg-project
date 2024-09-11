using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioEnum{
    BUTTON_CLICK,
    ADD_SCORE,
    ADD_TURN,
    GAME_END,
    // BGM,

}
[System.Serializable]
public struct MatchAudioClips{
    public AudioEnum AudioEnum;
    public AudioClip AudioClip;
}

public class SoundManager : MonoBehaviour
{
    // [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField]private AudioSource sfxAudioSource;
    [SerializeField] private MatchAudioClips[] matchAudioClips;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
