using UnityEngine;

public class Player : MonoBehaviour, IEnemyTarget
{
    [SerializeField] private int _movementSpeed;
    [SerializeField] private int _rotationSpeed;

    private  Mover _mover;

    private void Start()
    {
        _mover = new Mover(transform, _movementSpeed, _rotationSpeed);
    }

    private void Update()
    {
        _mover.ProcessMove();
    }
}
