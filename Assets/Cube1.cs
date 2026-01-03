using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1 : MonoBehaviour
{
    [SerializeField] private Transform _rotate;
    [SerializeField] private float _speed = 1;

    private void Update()
    {
        _rotate.Rotate(0, _speed, 0);
    }
}
