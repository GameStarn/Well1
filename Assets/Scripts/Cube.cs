using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Cube : MonoBehaviour
{
    private ObjectPool<Cube> _pool;

    private int _minLife = 2;
    private int _maxLife = 5;

    private bool _isReturning = false;

    public void SetPool(ObjectPool<Cube> pool)
    {
        _pool = pool;
    }

    public void StartLifeTimeer()
    {
        if (_isReturning) return;

        _isReturning = true;

        int lifeTime = Random.Range(_minLife, _maxLife);
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    public void ReturnToPool()
    {
        _isReturning = false;
        _pool.Release(this);
    }
}
