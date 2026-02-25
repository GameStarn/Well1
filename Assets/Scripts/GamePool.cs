using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GamePool : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Cube _cubePrefab;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(CreateCube, OnTakeFromPool, OnReturnToPool, OnDestroyCube, true, 10, 100);

        _cubeSpawner.Init(_pool);
    }

    private Cube CreateCube()
    {
        Cube cube = Instantiate(_cubePrefab);
        cube.LifeEnded += HandleLifeEnded;
        return cube;
    }

    private void HandleLifeEnded(Cube cube)
    {
        _pool.Release(cube);
    }

    private void OnTakeFromPool(Cube cube)
    {
        cube.gameObject.SetActive(true);

        if(cube.TryGetComponent(out ColorChanger collor))
        {
            collor.ResetColor();
        }
    }

    private void OnReturnToPool(Cube cube)
    {
        cube.gameObject.SetActive(false);
    }

    private void OnDestroyCube(Cube cube)
    {
        cube.LifeEnded -= HandleLifeEnded;
        Destroy(cube.gameObject);
    }
}
