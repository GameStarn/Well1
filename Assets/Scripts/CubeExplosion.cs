using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 5f;
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _upwardModifier = 0.5f;

    public void Explosion(Rigidbody rigidbody, Vector3 position)
    {
        if (rigidbody == null) return;

        rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius, _upwardModifier, ForceMode.Impulse);
    }
}
