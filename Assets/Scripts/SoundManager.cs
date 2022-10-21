using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager soundManager;

  AudioSource audioSource;
  [SerializeField] AudioClip[] hurtSounds;
  [SerializeField] AudioClip bonkSound;

  int randomHurtSounds;

  void Start()
  {
    soundManager = this;
    audioSource = GetComponent<AudioSource>();
  }

  public void PlayHurtSound()
  {
    if (!audioSource.isPlaying)
    {
      randomHurtSounds = Random.Range(0, hurtSounds.Length);
      audioSource.PlayOneShot(hurtSounds[randomHurtSounds]);
    }
  }

  public void PlayBonkSound()
  {
    if (!audioSource.isPlaying)
    {
      audioSource.PlayOneShot(bonkSound);
    }
  }
}
