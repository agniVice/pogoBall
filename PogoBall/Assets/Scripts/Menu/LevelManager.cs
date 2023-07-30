using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<Level> _levels;
    public Level CurrentLevel { get; private set; }
    public int CurrentLevelId { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
            Destroy(gameObject);
        else 
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public void AddLevel(Level level)
    {
        if(!_levels.Contains(level)) 
            _levels.Add(level);
    }
    public void LoadLevel(Level level)
    {
        if (!level.IsLocked)
        {
            CurrentLevelId = level.Id();
            SceneLoader.Instance.LoadScene(1);
        }
    }
    public void LoadNextLevel()
    {
        CurrentLevelId++;
    }

}
