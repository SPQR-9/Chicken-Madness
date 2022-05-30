using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceDrawer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private BoxCollider _template;
    [SerializeField] private float _tracingDelay;
    [SerializeField] private float _lifetime;

    private BoxCollider _point;

    private void OnValidate()
    {
        if (_lifetime <= _tracingDelay)
            _lifetime = _tracingDelay + 1;
    }

    private void Start()
    {
        _point = Instantiate(_template, transform.position, transform.rotation);
        InvokeRepeating(nameof(Draw), 0, _tracingDelay);
        Destroy(_point.gameObject, _lifetime);
    }

    private void OnEnable() => _effect.Play();

    private void OnDisable() => _effect.Stop();

    private void Draw()
    {
        if (enabled == false)
            return;

        var difference = _point.transform.position - transform.position;
        var rotation = Quaternion.FromToRotation(Vector3.forward, difference);
        _point = Instantiate(_template, transform.position, rotation);

        var size = _point.size;
        var center = _point.center;

        size.z = difference.magnitude;
        center.z = difference.magnitude / 2;

        _point.size = size;
        _point.center = center;

        Destroy(_point.gameObject, _lifetime);
    }
}
