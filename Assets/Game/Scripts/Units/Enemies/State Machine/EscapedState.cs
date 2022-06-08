using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapedState : ConcreteState<Vector3>
{
    private void OnEnable()
    {
        //Direction = transform.forward;
        //GetComponent<CapsuleCollider>().enabled = false;
        //Destroy(gameObject, 10f);
    }
}
