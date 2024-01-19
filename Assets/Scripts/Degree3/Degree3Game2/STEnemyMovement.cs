using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STEnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;
    private Transform player;


    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private STPlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<STPlayerAwarenessController>();
        _targetDirection = transform.up;
    }

    // private void FixedUpdate()
    // {
    //     UpdateTargetDirection();
    //     RotateTowardsTarget();
    //     SetVelocity();
    // }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;

        if (_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.up * _speed;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }
    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;

        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -_speed * Time.deltaTime);
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class STEnemyMovement : MonoBehaviour
// {
//     [SerializeField]
//     private float _speed;

//     [SerializeField]
//     private float _rotationSpeed;

//     [SerializeField]
//     private float _screenBorder;

//     private Rigidbody2D _rigidbody;
//     private STPlayerAwarenessController _playerAwarenessController;
//     private Vector2 _targetDirection;
//     private float _changeDirectionCooldown;
//     private Camera _camera;

//     private void Awake()
//     {
//         _rigidbody = GetComponent<Rigidbody2D>();
//         _playerAwarenessController = GetComponent<STPlayerAwarenessController>();
//         _targetDirection = transform.up;
//         _camera = Camera.main;
//     }

//     private void FixedUpdate()
//     {
//         UpdateTargetDirection();
//         RotateTowardsTarget();
//         SetVelocity();
//     }

//     private void UpdateTargetDirection()
//     {
//         HandleRandomDirectionChange();
//         HandlePlayerTargeting();
//         HandleEnemyOffScreen();
//     }

//     private void HandleRandomDirectionChange()
//     {
//         _changeDirectionCooldown -= Time.deltaTime;

//         if (_changeDirectionCooldown <= 0)
//         {
//             float angleChange = Random.Range(-90f, 90f);
//             Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
//             _targetDirection = rotation * _targetDirection;

//             _changeDirectionCooldown = Random.Range(1f, 5f);
//         }
//     }

//     private void HandlePlayerTargeting()
//     {
//         if (_playerAwarenessController.AwareOfPlayer)
//         {
//             _targetDirection = _playerAwarenessController.DirectionToPlayer;
//         }
//     }

//     private void HandleEnemyOffScreen()
//     {
//         Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

//         if ((screenPosition.x < _screenBorder && _targetDirection.x < 0) ||
//             (screenPosition.x > _camera.pixelWidth - _screenBorder && _targetDirection.x > 0))
//         {
//             _targetDirection = new Vector2(-_targetDirection.x, _targetDirection.y);
//         }

//         if ((screenPosition.y < _screenBorder && _targetDirection.y < 0) ||
//             (screenPosition.y > _camera.pixelHeight - _screenBorder && _targetDirection.y > 0))
//         {
//             _targetDirection = new Vector2(_targetDirection.x, -_targetDirection.y);
//         }
//     }

//     private void RotateTowardsTarget()
//     {
//         Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
//         Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

//         _rigidbody.SetRotation(rotation);
//     }

//     private void SetVelocity()
//     {
//         _rigidbody.velocity = transform.up * _speed;
//     }
// }
