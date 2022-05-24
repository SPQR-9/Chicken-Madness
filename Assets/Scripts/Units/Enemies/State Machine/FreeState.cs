using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRadar))]
public class FreeState : State
{
    private EnemyRadar _radar;

    protected override void Setup(Transform wall) => GoRandomWay();

    private void OnEnable()
    {
        _radar = GetComponent<EnemyRadar>();
        _radar.BorderCrossed += Reflect;
        _radar.WallDetected += Reflect;
    }

    private void OnDisable()
    {
        _radar.BorderCrossed -= Reflect;
        _radar.WallDetected -= Reflect;
    }

    private void Reflect(Vector3 normal)
    {
        Direction = normal;
    }

    private void GoRandomWay()
    {
        Direction = Map.RandomPoint - transform.position;
    }
}
