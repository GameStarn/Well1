using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChance : MonoBehaviour
{
    private float _minChance = 0f;
    private float _maxChance = 100f;

    public bool ShouldSpawn(float chance)
    {
         return Random.Range(_minChance, _maxChance) <= chance;
    }
}
