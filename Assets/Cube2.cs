using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : MonoBehaviour
{
    [SerializeField] private Vector3 _scale = new Vector3(1f, 1f, 1f);
    [SerializeField] private float _scaleSpeed = 1f;
    [SerializeField] private Transform _rotate;
    [SerializeField] private float _rotateSpeed = 1;
    [SerializeField] private Vector3 _movmentSpeed;
    private RaycastHit _hit;

    private void Update()
    {
        Vector3 lookDirection = transform.forward;

        transform.localScale += _scale * _scaleSpeed * Time.deltaTime;

        _rotate.Rotate(0, _rotateSpeed, 0);

        transform.position += transform.forward * _movmentSpeed.z * Time.deltaTime;

        if (Physics.Raycast(transform.position, lookDirection, out _hit, 50f))
        {
            Debug.Log("Вижу: " + _hit.collider.name);
        }
        else
        {
            Debug.Log("Ничего не вижу");
        }


    }
}
