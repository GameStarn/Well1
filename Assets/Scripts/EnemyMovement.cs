using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    public void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}