using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour, ILevelSpawner
{
    [SerializeField] private GameObject _obstaclePrefab;

    private List<GameObject> _obstacles = new List<GameObject>();

    public void Build(LevelInfo levelInfo)
    {
        int count = levelInfo.ObstaclePositions.Length;

        for (int i = 0; i < count; i++)
            _obstacles.Add(Instantiate(_obstaclePrefab, levelInfo.ObstaclePositions[i], Quaternion.Euler(levelInfo.ObstacleRotations[i])));
    }

    public void Clear()
    {
        foreach (GameObject go in _obstacles)
            Destroy(go);

        _obstacles.Clear();
}
}