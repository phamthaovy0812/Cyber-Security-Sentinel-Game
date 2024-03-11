using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHomeManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    [SerializeField] AudioClip background;
    public AudioClip typingBoard;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();

    }
    public void StopSFX()
    {
        SFXSource.Stop();
    }


}
