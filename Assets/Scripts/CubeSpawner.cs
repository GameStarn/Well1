using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private CubeChance _cubeChance;

    private int _minRand = 2;
    private int _maxRand = 7;

    public void Spawn(Vector3 position, Vector3 scale, float chance, CubeExplosion explosion)
    {
        if (!_cubeChance.ShouldSpawn(chance)) return;

        int count = Random.Range(_minRand, _maxRand);

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity);

            newCube.transform.localScale = scale * 0.5f;

            Cube cube = newCube.GetComponent<Cube>();
            cube.SetChance(chance / 2);

            RandomColor color = newCube.GetComponent<RandomColor>();
            if (color != null )
            {
                color.Color();
            }

            Rigidbody rigidbody = newCube.GetComponent<Rigidbody>();
            if( rigidbody != null )
            {
                explosion.Explosion(rigidbody, position);
            }
        }
    }
}
