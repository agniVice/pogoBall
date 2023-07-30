using System;
using System.Collections;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    public static LevelState Instance;

    public Action OnLevelReady;
    public Action OnLevelStart;
    public Action OnStarPickedUp;
    public Action OnLevelCompleted;
    public Action OnLevelFailed;

    public enum State
    {
        Ready,
        Start,
        StarPickedUp,
        Finish,
        Fail
    }
    public State CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    private void Start()
    {
        OnLevelReady?.Invoke();
    }
    public void ChangeState(State state)
    {
        CurrentState = state;
    }
    public void LevelSpawned()
    {
        CurrentState = State.Ready;
        OnLevelReady?.Invoke();
    }
    public void GameStarted()
    {
        CurrentState = State.Start;
        OnLevelStart?.Invoke();
    }
    public void StarPickedUp()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.StarPickUpSound);

        CurrentState = State.StarPickedUp;
        OnStarPickedUp?.Invoke();
    }
    public void LevelFailed()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.LevelSuccessSound);

        CurrentState = State.Fail;
        OnLevelFailed?.Invoke();
    }
    public void LevelCompleted()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.LevelSuccessSound);

        CurrentState = State.Finish;
        OnLevelCompleted?.Invoke();

        PlayerPrefs.SetInt("LevelLocked" + (LevelManager.Instance.CurrentLevelId+1), 0);
    }
}