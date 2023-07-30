using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    public Action OnPlayerMouseDown;
    public Action OnPlayerMouseUp;

    private bool _isEnabled;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    public void Initialize(LevelInfo levelInfo)
    {
        transform.position = levelInfo.BallPosition + new Vector3(0,0,-1);
    }
    private void OnMouseDown()
    {
        if (LevelState.Instance.CurrentState == LevelState.State.Ready)
            OnPlayerMouseDown?.Invoke();   
    }
    private void OnMouseUp()
    {
        if (LevelState.Instance.CurrentState == LevelState.State.Ready)
        {
            OnPlayerMouseUp?.Invoke();
            LevelState.Instance.ChangeState(LevelState.State.Start);
        }
    }
}
