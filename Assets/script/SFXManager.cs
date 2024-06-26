using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _onCorrectSFX;
    [SerializeField] private AudioClip _onIncorrectSFX;

    public void OnCorrectAnswer()
    {
        _audioSource.PlayOneShot(_onCorrectSFX);
    }

    public void OnIncorrectAnswer()
    {
        _audioSource.PlayOneShot(_onIncorrectSFX);
    }
}
