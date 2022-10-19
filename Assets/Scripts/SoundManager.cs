using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;

    AudioSource audioSource;
    [SerializeField] AudioClip[] hurtSounds;

    int randomHurtSounds;

    void Start()
    {
        soundManager = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHurtSound()
    {
        randomHurtSounds = Random.Range(0, hurtSounds.Length);
        audioSource.PlayOneShot(hurtSounds[randomHurtSounds]);
    }
}
