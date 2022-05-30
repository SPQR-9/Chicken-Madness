using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _offset;

    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = _point.position;
        _lastPosition.y -= _offset;
    }

    public Vector3 GetNextPoint()
    {
        _lastPosition.y += _offset;
        return _lastPosition;
    }
}
