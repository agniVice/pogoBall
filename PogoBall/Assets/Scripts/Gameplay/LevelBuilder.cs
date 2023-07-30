using UnityEngine;
using System.Collections.Generic;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder Instance;

    [SerializeField] private LevelInfo[] _levels;

    public LevelInfo CurrentLevelInfo { get; private set; }

    public GameObject[] SpawnerPrefabs;
    private List<GameObject> _spawners = new List<GameObject>();

    private void OnEnable()
    {
        LevelState.Instance.OnLevelReady += StartLevel;
    }
    private void OnDisable()
    {
        LevelState.Instance.OnLevelReady -= StartLevel;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    public void BuildLevel(int id)
    {
        foreach (GameObject spawner in SpawnerPrefabs)
        {
            var currentSpawner = Instantiate(spawner);

            _spawners.Add(currentSpawner);

            currentSpawner.GetComponent<ILevelSpawner>().Build(_levels[id]);
        }
        PlayerInput.Instance.Initialize(_levels[id]);
    }
    public void ResetLevel()
    {
        foreach (GameObject spawner in _spawners)
        {
            spawner.GetComponent<ILevelSpawner>().Clear();
            Destroy(spawner);
        }
        _spawners.Clear();
    }
    public void StartLevel()
    {
        if (_levels.Length == LevelManager.Instance.CurrentLevelId - 1)
        {
            SceneLoader.Instance.LoadScene(0);
            return;
        }

        ResetLevel();
        BuildLevel(LevelManager.Instance.CurrentLevelId-1);

        CurrentLevelInfo = _levels[LevelManager.Instance.CurrentLevelId - 1];
    }
}