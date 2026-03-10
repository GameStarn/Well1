using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyDestray : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 10f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}