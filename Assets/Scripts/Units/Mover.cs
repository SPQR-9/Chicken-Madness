using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private IInput _input;
    private Rigidbody _rigidbody;

    private Vector3 _direction;

    private const float _maxDegree = 180;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<IInput>();

        if (_input is null)
            throw new MissingComponentException("Mover requires one input component");
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void Update()
    {
        float delta = Time.deltaTime;

        if (delta > 0.02f)
            delta = 0.02f;

        _direction = _input.Direction;
        Move(_speed * delta);
        Rotate(_rotationSpeed * delta);
    }

    public void SpeedUp() => _speed *= 2;

    public void SpeedDown() => _speed /= 2;

    private void Move(float speed)
    {
        speed *= _direction.magnitude;
        _rigidbody.velocity = transform.forward * speed;
    }

    private void Rotate(float speed)
    {
        float angle = Vector3.SignedAngle(transform.forward, _direction, Vector3.up);

        if (angle >= _maxDegree)
            angle = _maxDegree - angle;

        transform.Rotate(new Vector3(0, angle / _maxDegree * speed, 0));
    }
}
