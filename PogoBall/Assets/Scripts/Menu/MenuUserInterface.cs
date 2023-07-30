using UnityEngine;
using UnityEngine.UI;

public class MenuUserInterface : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _levels;

    [Header("Audio")]
    [SerializeField] private Button _audioToggle;
    [SerializeField] private Image _audio;
    [SerializeField] private Sprite _audioEnabled;
    [SerializeField] private Sprite _audioDisabled;

    private void Start()
    {
        AudioManager.Instance.OnAudioChanged += ChangeAudioImage;
        _audioToggle.onClick.AddListener(AudioManager.Instance.ToggleAudio);

        ReturnToMenu();
    }
    private void OnDisable()
    {
        AudioManager.Instance.OnAudioChanged -= ChangeAudioImage;
    }
    private void ChangeAudioImage()
    {
        if (AudioManager.Instance.IsAudioEnabled) 
            _audio.sprite = _audioEnabled;
        else 
            _audio.sprite = _audioDisabled;
    }
    public void OpenSelectionLevel()
    {
        _menu.SetActive(false);
        _levels.SetActive(true);
    }
    public void ReturnToMenu()
    {
        _menu.SetActive(true);
        _levels.SetActive(false);
    }
}
