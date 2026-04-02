using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPrefab _enemyPrefab;
    [SerializeField] private RandomDirection _randomDirection;
    [SerializeField] private float _delay = 2f;

    [SerializeField] private Transform[] _spawnPoint;

    private EnemyMovement _enemyMovement;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (true)
        {
            CraftEnemys();

            yield return wait;
        }
    }

    public void CraftEnemys()
    {
        int randomIndex = Random.Range(0, _spawnPoint.Length);
        Vector3 spawnPos = _spawnPoint[randomIndex].position;

        Vector3 direction = _randomDirection.GetRandomDirection();

        Quaternion rotation = Quaternion.LookRotation(direction);

        EnemyPrefab enemy = Instantiate(_enemyPrefab, spawnPos, rotation);

        if (enemy.TryGetComponent(out EnemyMovement movement))
        {
            movement.Init(direction);
        }
    }
}