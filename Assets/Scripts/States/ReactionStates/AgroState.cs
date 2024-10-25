using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroState : IEnemyState
{
    private Enemy _enemy;
    private IEnemyTarget _enemyTarget;

    public AgroState(Enemy enemy, IEnemyTarget enemyTarget)
    {
        _enemy = enemy;
        _enemyTarget = enemyTarget;
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = (_enemyTarget.transform.position - _enemy.transform.position);

        direction.y = 0;

        return direction.normalized;

    }

    public void Process()
    {
        Vector3 direction = GetDirection();

        _enemy.ProcessMoveIn(direction);
    }
}
