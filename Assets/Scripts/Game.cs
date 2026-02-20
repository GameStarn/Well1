using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExplosion _explosion;
    [SerializeField] private RandomColor _color;
    [SerializeField] private CubeChance _chance;

    private void OnEnable()
    {
        _raycaster.CubeClicked += HandleCubeClicked;
    }
    private void OnDisable()
    {
        _raycaster.CubeClicked -= HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube cube)
    {
        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;
        float chance = cube.Chance;

        _explosion.Explosion(position);

        if (_chance.ShouldSpawn(chance))
        {
            List<Cube> newCubes = _spawner.Spawn(position, scale, chance);
            List<Rigidbody> rigidbodiesToExplode = new List<Rigidbody>();

            foreach (Cube newCube in newCubes)
            {
                if (newCube.TryGetComponent(out Rigidbody rd))
                    rigidbodiesToExplode.Add(rd);
            }
        }
        Destroy(cube.gameObject);
    }
}
