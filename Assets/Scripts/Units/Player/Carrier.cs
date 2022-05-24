using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerRadar))]
public class Carrier : MonoBehaviour
{
    [SerializeField] private Catcher _catcher;
    [SerializeField] private GameObject[] _cages;
    [SerializeField] private float _delay;

    private PlayerRadar _radar;

    private Coroutine _transfering;
    private int _count = 0;

    public event UnityAction<int> CountChanged;

    private void OnEnable()
    {
        _radar = GetComponent<PlayerRadar>();

        _catcher.Caught += OnEnemyCaught;
        _radar.EnteredWarehouse += StartTransfering;
        _radar.ExitedWarehouse += StopTransfering;
    }

    private void OnDisable()
    {
        _catcher.Caught -= OnEnemyCaught;
        _radar.EnteredWarehouse -= StartTransfering;
        _radar.ExitedWarehouse -= StopTransfering;
    }

    private void OnEnemyCaught()
    {
        if (_count >= _cages.Length)
            return;

        _cages[_count].SetActive(true);
        _count++;
        CountChanged?.Invoke(_count);
    }

    private void StartTransfering(Warehouse warehouse)
    {
        if (_transfering == null)
            _transfering = StartCoroutine(Transfer(warehouse));
    }

    private void StopTransfering(Warehouse warehouse)
    {
        if (_transfering != null)
            StopCoroutine(_transfering);

        _transfering = null;
    }

    private IEnumerator Transfer(Warehouse warehouse)
    {
        var wait = new WaitForSeconds(_delay);
        
        while (_count > 0)
        {
            _catcher.TakeAway();
            _count--;

            var template = _cages[_count];
            var cage = Instantiate(template, template.transform.position, template.transform.rotation);
            template.SetActive(false);

            cage.transform.DOMove(warehouse.Point, _delay);

            CountChanged?.Invoke(_count);
            yield return wait;
        }
    }
}
