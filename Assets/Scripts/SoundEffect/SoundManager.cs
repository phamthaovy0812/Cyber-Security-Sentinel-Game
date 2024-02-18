using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;                             //instance variable
    public static SoundManager Instance { get => instance; }
    [SerializeField] GameObject soundOnIcon;
    [SerializeField] GameObject soundOffIcon;
    private bool muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;

    }
    // public void LoadBeginSound()
    // {
    //     muted = false;
    //     UpdateButtonIcon();
    //     AudioListener.pause = muted;

    // }
    void Awake()
    {
        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance
            // DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);

        }
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.SetActive(true);
            soundOffIcon.SetActive(false);
        }
        else
        {
            soundOnIcon.SetActive(false);
            soundOffIcon.SetActive(true);
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;

    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);

    }

}
