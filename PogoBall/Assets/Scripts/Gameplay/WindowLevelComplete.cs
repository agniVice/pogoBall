using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class WindowLevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _levelComplete;

    private void OnEnable()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;

        LevelState.Instance.OnLevelCompleted += Show;
        LevelState.Instance.OnLevelReady += Hide;

        Hide();
    }
    private void OnDisable()
    {
        LevelState.Instance.OnLevelCompleted -= Show;
        LevelState.Instance.OnLevelReady -= Hide;
    }
    private void Show()
    {
        _panel.gameObject.SetActive(true);
        _levelComplete.text = "Level " + LevelManager.Instance.CurrentLevelId + "\n Complete";
    }
    private void Hide()
    {
        _panel.gameObject.SetActive(false);
    }
    public void Menu()
    {
        SceneLoader.Instance.LoadScene(0);
    }
    public void NextLevel()
    {
        LevelManager.Instance.LoadNextLevel();
        LevelState.Instance.LevelSpawned();
    }
    public void Restart()
    {
        LevelState.Instance.LevelSpawned();
    }
}