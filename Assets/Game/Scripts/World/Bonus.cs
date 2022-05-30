using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bonus : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Audio _audio;

    public float Pick()
    {
        Destroy(gameObject);
        _audio.Play();
        return _duration;
    }
}
