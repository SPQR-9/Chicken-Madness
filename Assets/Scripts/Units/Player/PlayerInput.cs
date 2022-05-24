using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    [SerializeField] private Joystick _input;

    private PlayerRadar _radar;
    private TraceDrawer _drawer;

    public Vector3 Direction { get; private set; }

    private void OnEnable()
    {
        _radar = GetComponent<PlayerRadar>();
        _drawer = GetComponent<TraceDrawer>();
        _radar.BonusPicked += OnBonusPicked;
    }

    private void OnDisable()
    {
        _radar.BonusPicked -= OnBonusPicked;
    }

    private void Update()
    {
        Direction = new Vector3(_input.Horizontal, 0, _input.Vertical);
    }

    private void OnBonusPicked(Bonus bonus)
    {
        _drawer.enabled = true;
        Invoke(nameof(Disable), bonus.Duration);
        Destroy(bonus.gameObject);
    }

    private void Disable() => _drawer.enabled = false;
}
