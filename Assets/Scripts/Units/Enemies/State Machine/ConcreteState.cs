using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyRadar))]
public abstract class ConcreteState<T> : State
{
    [SerializeField] private List<Transition> _transitions;

    protected EnemyRadar Radar { get; private set; }

    public void Enter(T value)
    {
        Radar = GetComponent<EnemyRadar>();
        enabled = true;

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Triggered += Exit;
        }

        Setup(value);
    }

    public override void InitializeFirst() => Enter(default);

    protected virtual void Setup(T value) { }

    private void Exit(State next)
    {
        foreach (var transition in _transitions)
        {
            transition.Triggered -= Exit;
            transition.enabled = false;
        }

        enabled = false;
        Switch(next);
    }
}
