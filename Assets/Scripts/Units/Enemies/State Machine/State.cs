using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour, IInput
{
    public Vector3 Direction { get; protected set; }

    public event UnityAction<State> Changed;

    protected void Switch(State state) => Changed?.Invoke(state);

    public abstract void InitializeFirst();
}
