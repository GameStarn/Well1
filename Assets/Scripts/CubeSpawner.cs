using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private int _minRand = 2;
    private int _maxRand = 7;

    public List<GameObject> Spawn(Vector3 position, Vector3 scale, float chance)
    {
        List<GameObject> cubes = new List<GameObject>();

        int count = Random.Range(_minRand, _maxRand);

        for (int i = 0; i < count; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, position, Quaternion.identity);

            newCube.transform.localScale = scale * 0.5f;

            Cube cube = newCube.GetComponent<Cube>();
            cube.SetChance(chance / 2);

            cubes.Add(newCube);
        }

        return cubes;
    }
}
