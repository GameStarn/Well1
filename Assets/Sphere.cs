using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Vector3 _nextPosition;

    private void Update()
    {
        transform.position += _nextPosition;
    }
}