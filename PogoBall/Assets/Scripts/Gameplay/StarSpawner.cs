using UnityEngine;

public class StarSpawner : MonoBehaviour, ILevelSpawner
{
    [SerializeField] private GameObject _starPrefab;

    private GameObject _star;

    public void Build(LevelInfo levelInfo)
    {
        _star = Instantiate(_starPrefab, levelInfo.StarPosition, Quaternion.Euler(levelInfo.StarRotation));
    }

    public void Clear()
    {
        Destroy(_star);
    }
}
