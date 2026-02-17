using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private float _chance = 100f;

    public float Chance => _chance;

    public void SetChance(float value)
    {
        _chance = value;
    }
}
