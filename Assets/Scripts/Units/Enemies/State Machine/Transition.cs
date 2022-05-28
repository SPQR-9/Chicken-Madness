using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Transition : MonoBehaviour
{
    public event UnityAction<State> Triggered;

    protected void Transit(State state) => Triggered?.Invoke(state);
}
