using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //private IdleName _idleName;
    //private ReactionName _reactionName;

    private IEnemyState _reactionState;
    private IEnemyState _idleState;

    private IEnemyState _currentState;

    private StateChooser _stateChooser;

    //private float _reactionDistance;
    private float _rotationSpeed = 500f;
    private float _movementSpeed = 10f;

    private void Awake()
    {
        _stateChooser = FindObjectOfType<StateChooser>();
    }

    private void Update()
    {
        _currentState.Process();
    }

    public void Initialize(IdleName idle, ReactionName reaction)
    {
        _idleState = _stateChooser.Initialize(idle, this);
        _reactionState = _stateChooser.Initialize(reaction, this);

        _currentState = _idleState;

    }

    public void ProcessMoveTo(Vector3 point)
    {
        Vector3 direction = GetDirectionTo(point);

        HandleMovement(direction);

        HandleRotation(direction);
    }

    public void ProcessMoveIn(Vector3 direction)
    {
        //Vector3 direction = GetDirectionTo(point);

        HandleMovement(direction);

        HandleRotation(direction);
    }

    private Vector3 GetDirectionTo(Vector3 point)
    {
        return (point - transform.position).normalized;
    }

    private void HandleMovement(Vector3 direction)
    {
        transform.Translate(_movementSpeed * direction * Time.deltaTime, Space.World);
    }

    private void HandleRotation(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            _currentState = _reactionState;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            _currentState = _idleState;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
