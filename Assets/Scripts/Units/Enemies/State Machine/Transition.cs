using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public event UnityAction<State> Triggered;

    protected void Trigger(Transform value)
    {
        _targetState.Enter(value);
        Triggered?.Invoke(_targetState);
    }
}
