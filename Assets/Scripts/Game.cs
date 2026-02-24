using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Game : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private GameObject _cubePrefab;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(CreateCube, OnTakeFromPool, OnReturnToPool, OnDestroyCube, true, 10, 100);

        _cubeSpawner.Init(_pool);
    }

    private Cube CreateCube()
    {
        Cube cube = Instantiate(_cubePrefab).GetComponent<Cube>();
        cube.SetPool(_pool);
        return cube;
    }

    private void OnTakeFromPool(Cube cube)
    {
        cube.gameObject.SetActive(true);

        if(cube.TryGetComponent(out CubeCollor collor))
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
        Destroy(cube.gameObject);
    }
}
