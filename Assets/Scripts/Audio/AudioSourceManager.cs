using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioSourceManager : MonoBehaviour
{
   [SerializeField] private AudioSource _back = default;
   [SerializeField] private AudioSource _embient =default;
   [SerializeField] private AudioSource _stepPlayer =default;
   [SerializeField] private AudioSource _stepEnemy = default;
   [SerializeField] private AudioSource _shotPlayer = default;
   [SerializeField] private AudioSource _someSoundEnemy = default;
   [SerializeField] private AudioSource _someSoundPlayer = default;

   private void Awake()
   {
       PlayAndStopSound._back = _back;
       PlayAndStopSound._embient = _embient;
       PlayAndStopSound._stepPlayer = _stepPlayer;
       PlayAndStopSound._shotPlayer = _shotPlayer;
       PlayAndStopSound._stepEnemy = _stepEnemy;
       PlayAndStopSound._someSoundEnemy = _someSoundEnemy;
       PlayAndStopSound._someSoundPlayer = _someSoundPlayer;
   }
}

public static class PlayAndStopSound
{
    public static AudioSource _back;
    public static AudioSource _embient;
    public static AudioSource _stepPlayer;
    public static AudioSource _stepEnemy;
    public static AudioSource _shotPlayer;
    public static AudioSource _someSoundEnemy;
    public static AudioSource _someSoundPlayer;

    public static void PlayEmbient()
    {
        _embient.PlayOneShot(_embient.clip);
    }
    public static void PlayBack()
    {
        _back.PlayOneShot(_back.clip);
    }
    public static void PlayStepPlayer()
    {
        _stepPlayer.PlayOneShot(_stepPlayer.clip);
    }
    public static void PlayStepEnemy()
    {
        _stepEnemy.PlayOneShot(_stepEnemy.clip);
    }
    public static void PlayShotPlayer()
    {
        _shotPlayer.PlayOneShot(_shotPlayer.clip);
    }
    public static void PlaySomeSoundEnemy()
    {
        _someSoundEnemy.PlayOneShot(_someSoundEnemy.clip);
    }
    public static void PlaySomeSoundPlayer()
    {
        _someSoundPlayer.PlayOneShot(_someSoundPlayer.clip);
    }
}
