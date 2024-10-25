using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private Queue<Transform> _points;

    private Transform _targetPoint;

    private Enemy _enemy;

    private float _minDistanceToPoint = 0.1f;



    public PatrolState(Enemy enemy, List<Transform> patrolPoints)
    {
        _enemy = enemy;

        _points = new Queue<Transform>();

        foreach (Transform point in patrolPoints)
        {
            _points.Enqueue(point);
        }

        _targetPoint = _points.Dequeue();
    }

    public void SwitchTarget()
    {
        _points.Enqueue(_targetPoint);

        _targetPoint = _points.Dequeue();
    }

    private bool IsPointReached() => (_enemy.transform.position - _targetPoint.position).magnitude <= _minDistanceToPoint;

    public void Process()
    {
        _enemy.ProcessMoveTo(_targetPoint.position);

        if (IsPointReached())
            SwitchTarget();
    }
}
