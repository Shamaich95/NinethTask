using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IEnemyState
{
    private Enemy _enemy;

    public DeathState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Process()
    {
        _enemy.Death();
    }
}
