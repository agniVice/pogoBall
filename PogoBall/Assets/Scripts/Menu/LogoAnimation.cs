using UnityEngine;
using DG.Tweening;

public class LogoAnimation : MonoBehaviour
{
    private Vector2 _startPosition;

    [SerializeField] private Ease _ease;
    [SerializeField] private float _time;

    private void Start()
    {
        _startPosition = transform.localPosition;

        DoAnimUp();
    }
    private void DoAnimUp()
    {
        transform.DOLocalMoveY(_startPosition.y + 40, _time)
            .SetLink(gameObject)
            .SetEase(_ease)
            .OnComplete(() => { DoAnimDown(); });
    }
    private void DoAnimDown()
    {
        transform.DOLocalMoveY(_startPosition.y - 40, _time)
            .SetLink(gameObject)
            .SetEase(_ease)
            .OnComplete(() => { DoAnimUp(); });
    }
    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
