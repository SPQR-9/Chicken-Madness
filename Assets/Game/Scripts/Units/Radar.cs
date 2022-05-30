using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Radar : MonoBehaviour
{
    [SerializeField] private float _radius = 1;

    public float Radius => _radius;

    private void Start()
    {
        var detector = GetComponent<SphereCollider>();
        detector.radius = _radius;
        detector.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) => EntranceDetected(other);

    private void OnTriggerExit(Collider other) => ExitDetected(other);

    private void OnCollisionEnter(Collision other) => AttachmentDetected(other);

    private void OnCollisionExit(Collision other) => DisattachmentDetected(other);

    protected abstract void EntranceDetected(Collider other);
    protected abstract void ExitDetected(Collider other);
    protected abstract void AttachmentDetected(Collision other);
    protected abstract void DisattachmentDetected(Collision other);
}
