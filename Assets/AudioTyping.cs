using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTyping : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource WishedListSource;
    [SerializeField] AudioSource removeWordSource;


    [Header("Audio Clip")]
    [SerializeField] AudioClip background;
    public AudioClip destroyWordAudio;
    public AudioClip wishlistAudio;
    public AudioClip winAudio;
    public AudioClip failAudio;
    public AudioClip correctTypingAudio;
    public AudioClip wrongTypingAudio;
    // [Header("Button Audio")]
    // public GameObject turnOffAudio;
    // public GameObject turnOnAudio;

    public static AudioTyping instance;
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
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();

    }
    public void PlaySoundWishlist(AudioClip clip)
    {
        WishedListSource.clip = clip;
        WishedListSource.Play();

    }
    public void PlaySoundRemoveWord(AudioClip clip)
    {
        removeWordSource.clip = clip;
        removeWordSource.Play();

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
    public void DestroySoundGame()
    {
        Destroy(gameObject);
    }
}
