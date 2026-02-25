using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Cube : MonoBehaviour
{
    public event Action<Cube> LifeEnded;

    private int _minLife = 2;
    private int _maxLife = 5;
    private bool _isActive = false;

    public void StartLifeTimeer()
    {
        if (_isActive) return;

        _isActive = true;

        int lifeTime = UnityEngine.Random.Range(_minLife, _maxLife);
        Invoke(nameof(EndLife), lifeTime);
    }

    public void EndLife()
    {
        _isActive = false;
        LifeEnded.Invoke(this);
    }
}
