using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider), typeof(Mover))]
public class EnemyAI : MonoBehaviour, IInput
{
    [SerializeField] private State _current;

    private CapsuleCollider _collider;
    private Mover _mover;
    private Vector3 _direction;

    public Vector3 Direction => _direction.normalized;

    private void Start()
    {
        _current.Enter(null);
        _current.Changed += Change;

        _collider = GetComponent<CapsuleCollider>();
        _mover = GetComponent<Mover>();
        _collider.enabled = true;
        _mover.enabled = true;
    }

    private void OnDisable()
    {
        _current.Changed -= Change;
        _collider.enabled = false;
        _mover.enabled = false;
    }

    private void Update()
    {
        _direction = _current.Direction;
    }

    private void Change(State state)
    {
        _current.Changed -= Change;
        _current = state;
        _current.Changed += Change;
    }
}
