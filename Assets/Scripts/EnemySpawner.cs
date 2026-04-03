using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private RandomDirection _randomDirection;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private Transform[] _spawnPoint;


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

        EnemyMovement spawnedEnemy = Instantiate(_enemyPrefab, spawnPos, rotation);

        spawnedEnemy.Init(direction);
    }
}