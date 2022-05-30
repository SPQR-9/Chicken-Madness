using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntedTransition : ConcreteTransition<Transform>
{
    private void OnEnable()
    {
        Radar = GetComponent<EnemyRadar>();
        Radar.ChaseStarted += Trigger;
    }

    private void OnDisable()
    {
        Radar.ChaseStarted -= Trigger;
    }
}
