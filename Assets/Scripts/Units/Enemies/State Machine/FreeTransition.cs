using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTransition : Transition
{
    private EnemyRadar _radar;

    private void OnEnable()
    {
        _radar = GetComponent<EnemyRadar>();
        _radar.ChaseEnded += Trigger;
    }

    private void OnDisable()
    {
        _radar.ChaseEnded -= Trigger;
    }
}
