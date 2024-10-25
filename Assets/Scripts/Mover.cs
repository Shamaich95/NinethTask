using UnityEngine;

public class Mover
{
    private string _horizontalAxisName = "Horizontal";
    private string _verticallAxisName = "Vertical";
    private float _minValueToMove = 0.1f;

    private Transform _transform;
    private float _rotationSpeed;

    public Mover(Transform transform, float movementSpeed, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
        MovementSpeed = movementSpeed;
    }

    public float MovementSpeed { get; private set; }

    public void ProcessMove()
    {
        Vector3 direction = GetDirection();

        if (direction.magnitude <= _minValueToMove)
            return;

        HandleMovement(direction);

        HandleRotation(direction);
    }

    private Vector3 GetDirection()
    {
        float xInput = Input.GetAxisRaw(_horizontalAxisName);
        float zInput = Input.GetAxisRaw(_verticallAxisName);

        return new Vector3(xInput, 0, zInput).normalized;
    }

    private void HandleMovement(Vector3 direction)
    {
        _transform.Translate(MovementSpeed * direction * Time.deltaTime, Space.World);
    }

    private void HandleRotation(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }
}
