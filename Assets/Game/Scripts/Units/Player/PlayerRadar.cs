using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class PlayerRadar : Radar
{
    public event UnityAction<Warehouse> EnteredWarehouse;
    public event UnityAction<Warehouse> ExitedWarehouse;
    public event UnityAction<Bonus> BonusPicked;

    protected override void EntranceDetected(Collider other)
    {
        if (other.TryGetComponent(out Warehouse warehouse))
            EnteredWarehouse?.Invoke(warehouse);

        if (other.TryGetComponent(out Bonus bonus))
            BonusPicked?.Invoke(bonus);
    }

    protected override void ExitDetected(Collider other)
    {
        if (other.TryGetComponent(out Warehouse warehouse))
            ExitedWarehouse?.Invoke(warehouse);
    }

    protected override void AttachmentDetected(Collision collision) { }

    protected override void DisattachmentDetected(Collision other) { }
}
