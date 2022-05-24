using UnityEngine;

[RequireComponent(typeof(EnemyRadar))]
public class HuntedState : State
{
    private EnemyRadar _radar;
    private Transform _hunter;

    private void OnEnable()
    {
        _radar = GetComponent<EnemyRadar>();
        _radar.BorderCrossed += CrossTheBorder;
    }

    private void OnDisable()
    {
        _radar.BorderCrossed -= CrossTheBorder;
    }

    private void Update()
    {
        var radius = _radar.Radius;
        float distance = float.MinValue;

        if (distance <= radius)
        {
            distance = Vector3.Distance(_hunter.position, transform.position);
            Direction = transform.position - _hunter.position;
        }
    }

    protected override void Setup(Transform hunter) => _hunter = hunter;

    private void CrossTheBorder(Vector3 point)
    {
        GetComponent<Collider>().enabled = false;
        enabled = false;
        Destroy(gameObject, 2f);
    }
}
