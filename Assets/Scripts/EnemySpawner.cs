using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _EnemyPrefab;
    [SerializeField] private RandomDirection _randomDirection;
    [SerializeField] private float _delay = 2f;

    [SerializeField] private Transform[] _spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            EnemyCrafter();

            yield return new WaitForSeconds(_delay);
        }
    }

    public void EnemyCrafter()
    {
        int randomIndex = Random.Range(0, _spawnPoint.Length);

        Quaternion randomRotation = _randomDirection.GetRandomRotation();

        Vector3 spawnPos = _spawnPoint[randomIndex].position;

        Instantiate(_EnemyPrefab, spawnPos, randomRotation);
    }
}