using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRadar))]
public class FreeState : ConcreteState<Transform>
{
    protected override void Setup(Transform wall) => GoRandomWay();

    private void OnEnable()
    {
        Radar.BorderCrossed += Reflect;
        Radar.WallDetected += Reflect;
    }

    private void OnDisable()
    {
        Radar.BorderCrossed -= Reflect;
        Radar.WallDetected -= Reflect;
    }

    private void Reflect(Vector3 normal) => Direction = normal;

    private void GoRandomWay() => Direction = Map.RandomPoint - transform.position;
}
