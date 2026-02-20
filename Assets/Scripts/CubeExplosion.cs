using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 4f;
    [SerializeField] private float _upwardModifier = 1f;

    public void Explosion(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rb))
            {
                rb.AddExplosionForce(_explosionForce, position, _explosionRadius, _upwardModifier, ForceMode.Impulse);
            }
        }
    }
}
