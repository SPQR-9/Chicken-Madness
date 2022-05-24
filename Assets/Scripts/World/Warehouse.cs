using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private Transform _point;

    public Vector3 Point => _point.position;
}
