using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Collider _SpawnZone;
    [SerializeField] private float _dely = 0.1f;

    private ObjectPool<Cube> _pool;

    private CubeDestroy _cubeDestroy;

    public void Init(ObjectPool<Cube> pool)
    {
        _pool = pool;
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_dely);
        }
    }

    private void Spawn()
    {
        Bounds bounds = _SpawnZone.bounds;

        Vector3 spawnPoint = new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
        );

        Cube cube = _pool.Get();
        cube.transform.position = spawnPoint;
    }
}
