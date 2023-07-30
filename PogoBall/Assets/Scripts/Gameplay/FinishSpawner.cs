using System.Collections;
using UnityEngine;

public class FinishSpawner : MonoBehaviour, ILevelSpawner
{
    [SerializeField] private GameObject _finishPrefab;

    private GameObject _finish;

    public void Build(LevelInfo levelInfo)
    {
        _finish = Instantiate(_finishPrefab, levelInfo.FinishPosition, Quaternion.Euler(levelInfo.FinishRotation));
    }

    public void Clear()
    {
        Destroy(_finish);
    }
}