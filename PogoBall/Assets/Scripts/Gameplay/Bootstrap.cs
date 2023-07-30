using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _playerInputPrefab;
    [SerializeField] private GameObject _userInterfaceManagerPrefab;
    [SerializeField] private GameObject _levelStatePrefab;
    [SerializeField] private GameObject _levelBuilderPrefab;

    private void Awake()
    {
        InitializeAll();
    }
    private void InitializeAll()
    {
        Instantiate(_levelStatePrefab);
        Instantiate(_userInterfaceManagerPrefab);
        Instantiate(_levelBuilderPrefab);
        Instantiate(_playerInputPrefab);
    }
}