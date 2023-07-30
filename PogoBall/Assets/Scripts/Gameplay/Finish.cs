using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnEnable()
    {
        LevelState.Instance.OnStarPickedUp += OnStarPickedUp;
    }
    private void OnDisable()
    {
        LevelState.Instance.OnStarPickedUp -= OnStarPickedUp;
    }
    private void OnStarPickedUp()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}