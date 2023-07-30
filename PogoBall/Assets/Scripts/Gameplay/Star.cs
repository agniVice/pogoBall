using UnityEngine;

public class Star : MonoBehaviour
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
        Destroy(gameObject);
    }
}
