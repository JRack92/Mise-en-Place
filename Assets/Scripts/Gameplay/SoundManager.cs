using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (_audioSource != null && clip != null)
        {
            _audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is null.");
        }
    }
}
