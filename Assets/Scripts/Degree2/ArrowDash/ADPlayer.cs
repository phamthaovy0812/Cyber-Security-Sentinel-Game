using UnityEngine;


public class ADPlayer : MonoBehaviour
{
    [SerializeField]
    private Vector3 _startSpawnPos;

    [SerializeField]
    private float _minX, _maxX;

    [SerializeField]
    private float _moveTime;

    [SerializeField]
    private ParticleSystem _trailParticle;

    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private AudioClip _moveClip, _pointClip, _loseClip;

    private float speed;
    private bool canClick, canMove;

    private void Awake()
    {
        transform.position = _startSpawnPos;
        _trailParticle.Pause();
        canClick = false;
        canMove = false;
        speed = (_maxX - _minX) / _moveTime;
    }


    private void OnEnable()
    {
        ADGameManager.Instance.GameStarted += GameStarted;
    }

    private void OnDisable()
    {
        ADGameManager.Instance.GameStarted -= GameStarted;
    }

    private void GameStarted()
    {
        _trailParticle.Play();
        canMove = true;
        canClick = true;
    }

    private void Update()
    {
        if (!canClick) return;
        if(Input.GetMouseButtonDown(0))
        {
            ADAudioManager.Instance.PlaySound(_moveClip);
            speed *= -1;
        }
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        transform.Translate(speed * Time.fixedDeltaTime * Vector3.right);
        if (transform.position.x < _minX || transform.position.x > _maxX) speed *= -1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ADConstants.Tags.SCORE))
        {
            ADAudioManager.Instance.PlaySound(_pointClip);
            collision.gameObject.GetComponent<ADScore>().DestroySprite();
            ADGameManager.Instance.UpdateScore();
            return;
        }

        if(collision.CompareTag(ADConstants.Tags.OBSTACLE))
        {
            ADAudioManager.Instance.PlaySound(_loseClip);
            ADGameManager.Instance.EndGame();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            canMove = false;
            canClick = false;
            return;
        }
        
    }
}