using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitForceField : MonoBehaviour
{
    public float lifetime;
    public Transform parentUnit;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        if (parentUnit != null)
        {
            transform.position = parentUnit.position;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
