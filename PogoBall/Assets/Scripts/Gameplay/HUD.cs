using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshPro _levelNumber;
    [SerializeField] private GameObject _restartButton;

    private void OnEnable()
    {
        LevelState.Instance.OnLevelFailed += ShowRestartButton;
        LevelState.Instance.OnLevelReady += HideRestartButton;
        LevelState.Instance.OnLevelReady += UpdateLevelNumber;
    }
    private void OnDisable()
    {
        LevelState.Instance.OnLevelFailed -= ShowRestartButton;
        LevelState.Instance.OnLevelReady -= HideRestartButton;
    }
    private void UpdateLevelNumber()
    {
        _levelNumber.text = "level " + LevelManager.Instance.CurrentLevelId.ToString();
    }
    private void ShowRestartButton()
    {
        _restartButton.SetActive(true);
    }
    private void HideRestartButton()
    {
        _restartButton.SetActive(false);
    }
    public void Restart()
    {
        LevelState.Instance.LevelSpawned();
    }
    public void Menu()
    {
        SceneLoader.Instance.LoadScene(0);
    }
}