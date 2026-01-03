using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private Vector3 _scale = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        transform.localScale += _scale * _speed * Time.deltaTime;
    }
}
