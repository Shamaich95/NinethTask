using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private IdleName _idle;
    [SerializeField] private ReactionName _reaction;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _initializeOffset;

    private Enemy _enemy;

    private void Start()
    {
        HadleSpawn();
    }

    private void HadleSpawn()
    {
        _enemy = Instantiate(_enemyPrefab, transform.position + _initializeOffset, Quaternion.identity);

        _enemy.Initialize(_idle, _reaction);
    }
}
