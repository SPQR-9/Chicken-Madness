using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTransition : ConcreteTransition<Transform>
{
    private void OnEnable()
    {
        Radar = GetComponent<EnemyRadar>();
        Radar.ChaseEnded += Trigger;
    }

    private void OnDisable()
    {
        Radar.ChaseEnded -= Trigger;
    }
}
