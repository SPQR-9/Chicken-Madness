using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Catcher : MonoBehaviour
{
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

        _count++;
        Caught?.Invoke();

        enemy.transform.parent = transform.parent;
        enemy.enabled = false;
        enemy.transform.DOMove(_point.position, _duration);
        enemy.transform.DOScale(Vector3.zero, _duration);

        Destroy(enemy.gameObject, _duration);
    }

    public void TakeAway()
    {
        _count--;
    }
}
