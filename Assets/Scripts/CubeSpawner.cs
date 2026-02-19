using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _minRand = 2;
    private int _maxRand = 7;

    public List<Cube> Spawn(Vector3 position, Vector3 scale, float chance)
    {
        List<Cube> cubes = new List<Cube>();

        int count = Random.Range(_minRand, _maxRand);

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity);

            newCube.transform.localScale = scale * 0.5f;

            if (newCube.TryGetComponent(out RandomColor newColor))
                newColor.SetRandomColor();

            Cube cube = newCube.GetComponent<Cube>();
            cube.SetChance(chance / 2);

            cubes.Add(newCube);
        }

        return cubes;
    }
}
