using UnityEngine;

[RequireComponent(typeof(EnemyRadar))]
public class HuntedState : ConcreteState<Transform>
{
    private Transform _hunter;

    private void Update()
    {
        Direction = transform.position - _hunter.position;
    }

    protected override void Setup(Transform hunter) => _hunter = hunter;
}
