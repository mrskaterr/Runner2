using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] BoxCollider DamageCollider;

    public void DisableCollider()
    {
        DamageCollider.enabled=false;
    }
}
