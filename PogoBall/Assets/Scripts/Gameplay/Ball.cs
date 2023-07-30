using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Prefabs")]

    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private GameObject _particlePrefab;

    [Space]
    [Header("BallSettings")]

    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _timeToDestroy = 5f;

    [SerializeField] private float _currentTime;

    private Rigidbody2D _rigidbody;
    private LineRenderer _lineRenderer;

    private Vector3 _direction;

    private bool _isMoving;
    private bool _isAimed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        SpawnLine();   
    }
    private void OnEnable()
    {
        PlayerInput.Instance.OnPlayerMouseDown += OnPlayerMouseDown;
        PlayerInput.Instance.OnPlayerMouseUp += OnPlayerMouseUp;
    }
    private void OnDisable()
    {
        PlayerInput.Instance.OnPlayerMouseDown -= OnPlayerMouseDown;
        PlayerInput.Instance.OnPlayerMouseUp -= OnPlayerMouseUp;
    }
    private void FixedUpdate()
    {
        Move();
        UpdateTimer();
        UpdateTrajectory();
    }
    private void Move()
    {
        if (_isMoving)
            _rigidbody.velocity = _direction.normalized * _speed;
    }
    private void UpdateTimer()
    {
        if (_isMoving)
        {
            if (_currentTime <= _timeToDestroy)
                _currentTime += Time.fixedDeltaTime;
            else
            {
                LevelState.Instance.LevelFailed();

                SpawnParticle();
                Destroy(gameObject);
            }
        }
    }
    private void UpdateTrajectory()
    {
        if (_isAimed)
        {
            Vector2 differenve = _lineRenderer.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _direction = differenve.normalized;
            _lineRenderer.SetPosition(1, _direction * 20f);
        }
    }
    private void HideTrajectory()
    {
        _lineRenderer.SetPosition(1, Vector2.zero);

        _isAimed = false;
    }
    private void SpawnLine()
    {
        _lineRenderer = Instantiate(_linePrefab).GetComponent<LineRenderer>();
        _lineRenderer.GetComponent<LineMovement>().Ball = transform;
    }
    private void SpawnParticle()
    {
        var particle = Instantiate(_particlePrefab).GetComponent<ParticleSystem>();
        particle.transform.position = transform.position;
        particle.Play();

        Destroy(particle.gameObject, 3f);
    }
    private void OnDestroy()
    {
        if(_lineRenderer != null)
            Destroy(_lineRenderer.gameObject);
    }
    private void OnPlayerMouseDown()
    {
        if (LevelState.Instance.CurrentState == LevelState.State.Ready)
        {
            _isAimed = true;
        }
    }
    private void OnPlayerMouseUp()
    {
        if (LevelState.Instance.CurrentState == LevelState.State.Ready)
        {
            HideTrajectory();

            _isMoving = true;

            _currentTime = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AudioManager.Instance.PlaySound(AudioManager.Instance.BallSound, true);
            _direction = Vector3.Reflect(_direction, collision.contacts[0].normal);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            if (LevelState.Instance.CurrentState == LevelState.State.StarPickedUp)
            {
                LevelState.Instance.LevelCompleted();

                SpawnParticle();

                transform.position = LevelBuilder.Instance.CurrentLevelInfo.FinishPosition;
                _rigidbody.velocity = Vector2.zero;
                _isMoving = false;
            }
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            if (LevelState.Instance.CurrentState == LevelState.State.Start)
            {
                LevelState.Instance.StarPickedUp();
            }
        }
    }
}
