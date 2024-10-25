using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChooser : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeReference] private Player _enemyTarget;

    private IEnemyState _state;

    public IEnemyState Initialize(IdleName idleName, Enemy enemy)
    {
        switch (idleName)
        {
            case IdleName.Nothing:
                _state = new NothingState();
                break;

            case IdleName.Patrol:
                _state = new PatrolState(enemy, _patrolPoints);
                break;

            case IdleName.Random:
                _state = new RandomState(enemy);
                break;

            default:
                Debug.LogError("This state doesn't exist");
                break;
        }

        return _state;
    }

    public IEnemyState Initialize(ReactionName reactionName, Enemy enemy)
    {
        switch (reactionName)
        {
            case ReactionName.Scary:
                _state = new ScaryState(enemy, _enemyTarget);
                break;

            case ReactionName.Agro:
                _state = new AgroState(enemy, _enemyTarget);
                break;

            case ReactionName.Death:
                _state = new DeathState(enemy);
                break;

            default:
                Debug.LogError("This state doesn't exist");
                break;
        }

        return _state;
    }
}
