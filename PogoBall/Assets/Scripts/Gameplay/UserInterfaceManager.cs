using System.Collections;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Instance;

    [SerializeField] private GameObject _hudPrefab;
    [SerializeField] private GameObject _windowLevelCompletePrefab;

    private HUD _hud;
    private WindowLevelComplete _windowLevelComplete;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        Initialize();
    }
    private void Initialize()
    {
        _hud = Instantiate(_hudPrefab).GetComponent<HUD>();
        _windowLevelComplete = Instantiate(_windowLevelCompletePrefab).GetComponent<WindowLevelComplete>();
    }
}