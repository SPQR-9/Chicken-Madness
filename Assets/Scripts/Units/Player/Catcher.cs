using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections;

public class Catcher : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Transform _point;
    [SerializeField] private float _duration;
    [SerializeField] private int _capacity;

    private int _count = 0;

    public event UnityAction Caught;

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

        enemy.enabled = false;
        enemy.transform.parent = _point.parent;
        enemy.transform.DOLocalMove(_point.localPosition, _duration);
        enemy.transform.DOScale(enemy.transform.localScale / 2, _duration);

        Destroy(enemy.gameObject, _duration);
        Invoke(nameof(Catch), _duration);
    }

    private void Catch()
    {
        _count++;
        Caught?.Invoke();
        _effect.Play();
    }

    public void TakeAway()
    {
        _count--;
    }
}
