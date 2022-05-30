using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapedTransition : ConcreteTransition<Vector3>
{
    private void OnEnable()
    {
        Radar = GetComponent<EnemyRadar>();
        Radar.BorderCrossed += Trigger;
    }

    private void OnDisable()
    {
        Radar.BorderCrossed -= Trigger;
    }
}
