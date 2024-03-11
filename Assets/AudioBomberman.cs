using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class AudioBomberman : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource explodedSource;


    [Header("Audio Clip")]
    [SerializeField] AudioClip background;
    public AudioClip explodedAudio;
    public AudioClip winAudio;
    public AudioClip failAudio;
    public AudioClip correctAudio;
    public AudioClip wrongAudio;
    // [Header("Button Audio")]
    // public GameObject turnOffAudio;
    // public GameObject turnOnAudio;

    public static AudioBomberman instance;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayExplode(AudioClip clip)
    {
        explodedSource.clip = clip;
        explodedSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();

    }
    public void StopSFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Stop();
    }
    // public void PlayAllAudio()
    // {
    //     turnOffAudio.SetActive(true);
    //     turnOnAudio.SetActive(false);
    //     musicSource.clip = background;
    //     musicSource.Play();
    //     explodedSource.Play();
    // }
    // public void StopAllAudio()
    // {
    //     turnOffAudio.SetActive(false);
    //     turnOnAudio.SetActive(true);
    //     musicSource.Stop();
    //     SFXSource.Stop();
    //     explodedSource.Stop();
    // }
    public void DestroySoundGameBomberman()
    {
        Destroy(gameObject);
    }
}
