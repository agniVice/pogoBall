using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public bool IsAudioEnabled { private set; get; }

    public Action OnAudioChanged;

    public AudioClip BallSound;
    public AudioClip StarPickUpSound;
    public AudioClip LevelSuccessSound;

    [SerializeField] private GameObject _soundPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
            Destroy(gameObject);
        else 
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        IsAudioEnabled = Convert.ToBoolean(PlayerPrefs.GetInt("IsAudioEnabled", 1));
        OnAudioChanged?.Invoke();
    }
    public void ToggleAudio()
    {
        IsAudioEnabled = !IsAudioEnabled;
        PlayerPrefs.SetInt("IsAudioEnabled", Convert.ToInt32(IsAudioEnabled));
        OnAudioChanged?.Invoke();
    }
    public void PlaySound(AudioClip clip, bool randomPitch = false)
    {
        if (!IsAudioEnabled)
            return;

        if(randomPitch)
            Instantiate(_soundPrefab).GetComponent<Sound>().PlaySound(clip, UnityEngine.Random.Range(0.8f, 1.1f));
        else
            Instantiate(_soundPrefab).GetComponent<Sound>().PlaySound(clip);

    }
}
