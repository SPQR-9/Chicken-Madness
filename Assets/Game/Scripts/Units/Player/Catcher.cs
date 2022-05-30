using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections;

public class Catcher : MonoBehaviour
{
    [SerializeField] private UnityEvent _caught;
    [SerializeField] private UnityEvent _takenAway;
    [SerializeField] private Transform _point;
    [Space]
    [SerializeField] private float _duration;
    [SerializeField] private int _capacity;

    private int _count = 0;

    public event UnityAction Caught
    {
        add => _caught.AddListener(value);
        remove => _caught.RemoveListener(value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;

        if (other.TryGetComponent(out EnemyAI enemy))
            Catch(enemy);
    }

    private void Catch(EnemyAI enemy)
    {
        if (_count >= _capacity)
            return;

        _count++;

        enemy.enabled = false;
        enemy.transform.parent = _point.parent;
        enemy.transform.DOLocalMove(_point.localPosition, _duration);
        enemy.transform.DOScale(enemy.transform.localScale / 2, _duration);

        Destroy(enemy.gameObject, _duration);
        Invoke(nameof(Catch), _duration);
    }

    private void Catch()
    {
        _caught.Invoke();
        Handheld.Vibrate();
    }

    public void TakeAway()
    {
        _count--;
        Handheld.Vibrate();
        _takenAway.Invoke();
    }
}
