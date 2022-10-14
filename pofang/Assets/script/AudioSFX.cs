using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    //管理播放音效
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip magicMissileLaunchClip;
    [SerializeField] private AudioClip takeDamageClip;

    public void PlayGameover()
    {
        audioSource.PlayOneShot(gameOverClip);
    }
    public void PlayMagicMissileLaunchClip()
    {
        audioSource.PlayOneShot(magicMissileLaunchClip);
    }
    public void PlayTakeDamageClip()
    {
        audioSource.PlayOneShot(takeDamageClip);
    }
}
