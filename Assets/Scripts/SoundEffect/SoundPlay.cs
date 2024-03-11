using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public static SoundPlay Instance { get; private set; }
    [SerializeField] private AudioSource _effectSource;
    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

}