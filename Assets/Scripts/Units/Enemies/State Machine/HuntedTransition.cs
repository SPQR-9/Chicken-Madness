using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRadar))]
public class HuntedTransition : Transition
{
    private EnemyRadar _radar;

    private void OnEnable()
    {
        _radar = GetComponent<EnemyRadar>();
        _radar.ChaseStarted += Trigger;
    }

    private void OnDisable()
    {
        _radar.ChaseStarted -= Trigger;
    }
}
