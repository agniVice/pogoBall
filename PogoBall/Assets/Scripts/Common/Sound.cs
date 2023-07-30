using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound(AudioClip audioClip, float pitch = 1f)
    {
        _audioSource.clip = audioClip;
        _audioSource.pitch = pitch;
        _audioSource.Play();

        Destroy(gameObject, audioClip.length + 1);
    }
}