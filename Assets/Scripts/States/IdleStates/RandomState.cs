using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomState : IEnemyState
{
    private Vector3 _randomPoint;

    private float _minDistanceToPoint = 0.1f;

    private float _passedTime = 0f;

    private float _maxTime = 1f;

    private Enemy _enemy;

    public RandomState(Enemy enemy)
    {
        _enemy = enemy;
        _randomPoint = GetRandomPoint();
    }

    private Vector3 GetRandomPoint() => new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));

    private void SwitchTarget() => _randomPoint = GetRandomPoint();

    private bool IsTimeOver()
    {
        if (_passedTime >= _maxTime)
        {
            _passedTime = 0f;

            return true;
        }

        return false;
    }

    private bool IsPointReached() => (_enemy.transform.position - _randomPoint).magnitude <= _minDistanceToPoint;

    public void Process()
    {
        _passedTime += Time.deltaTime;

        if (IsTimeOver() || IsPointReached())
            SwitchTarget();

        _enemy.ProcessMoveTo(_randomPoint);
    }
}
