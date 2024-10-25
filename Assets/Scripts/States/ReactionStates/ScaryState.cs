using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryState : IEnemyState
{
    private Enemy _enemy;
    private IEnemyTarget _enemyTarget;

    public ScaryState(Enemy enemy, IEnemyTarget enemyTarget)
    {
        _enemy = enemy;
        _enemyTarget = enemyTarget;
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = (_enemy.transform.position - _enemyTarget.transform.position);

        direction.y = 0;

        return direction.normalized;

    }

    public void Process()
    {
        Vector3 direction = GetDirection();

        _enemy.ProcessMoveIn(direction);
    }
}
