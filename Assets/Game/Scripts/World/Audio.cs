using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        int index = Random.Range(0, _clips.Length);
        _audio.PlayOneShot(_clips[index]);
    }
}
