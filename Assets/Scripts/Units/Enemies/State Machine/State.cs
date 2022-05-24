using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour, IInput
{
    [SerializeField] private List<Transition> _transitions;

    public Vector3 Direction { get; protected set; }

    public event UnityAction<State> Changed;

    public void Enter(Transform value)
    {
        enabled = true;

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Triggered += Exit;
        }

        Setup(value);
    }

    protected virtual void Setup(Transform value) { }

    private void Exit(State next)
    {
        foreach (var transition in _transitions)
        {
            transition.Triggered -= Exit;
            transition.enabled = false;
        }

        enabled = false;
        Changed?.Invoke(next);
    }
}
