using UnityEngine;

public class BallSpawner : MonoBehaviour, ILevelSpawner
{
    [SerializeField] private GameObject _ballPrefab;

    private GameObject _ball;

    public void Build(LevelInfo levelInfo)
    {
        _ball = Instantiate(_ballPrefab, levelInfo.BallPosition, Quaternion.Euler(levelInfo.BallRotation));
    }
    public void Clear()
    {
        Destroy(_ball);
    }

}