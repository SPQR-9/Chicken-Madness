using UnityEngine;
using UnityEngine.Events;

public class EnemyRadar : Radar
{
    public event UnityAction<Transform> ChaseStarted;
    public event UnityAction<Transform> ChaseEnded;

    public event UnityAction<Vector3> WallDetected;
    public event UnityAction<Vector3> BorderCrossed;

    protected override void EntranceDetected(Collider other)
    {
        if (other.TryGetComponent(out PlayerInput player))
            ChaseStarted?.Invoke(player.transform);
    }

    protected override void ExitDetected(Collider other)
    {
        if (other.TryGetComponent(out PlayerInput player))
            ChaseEnded?.Invoke(player.transform);
    }

    protected override void AttachmentDetected(Collision collision)
    {
        var other = collision.transform;
        if (other.TryGetComponent(out Border border))
            BorderCrossed?.Invoke(collision.contacts[0].normal.normalized);

        if (other.TryGetComponent(out Wall wall))
            WallDetected?.Invoke(collision.contacts[0].normal.normalized);
    }

    protected override void DisattachmentDetected(Collision other)
    {
        
    }
}
