using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyRadar))]
public abstract class ConcreteTransition<T> : Transition
{
    [SerializeField] private ConcreteState<T> _targetState;

    protected EnemyRadar Radar;

    protected void Trigger(T value)
    {
        _targetState.Enter(value);
        Transit(_targetState);
    }
}
