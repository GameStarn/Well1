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
        _raycaster.OnCubeClicked += HandleCubeClicked;
    }
    private void OnDestroy()
    {
        _raycaster.OnCubeClicked -= HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube cube)
    {
        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;
        float chance = cube.Chance;

        if (_chance.ShouldSpawn(chance))
        {
            List<GameObject> newCubes = _spawner.Spawn(position, scale, chance);
            List<Rigidbody> rigidbodiesToExplode = new List<Rigidbody>();

            foreach (GameObject newCube in newCubes)
            {
                if (newCube.TryGetComponent(out RandomColor newColor))
                    newColor.SetRandomColor();

                if (newCube.TryGetComponent(out Rigidbody rd))
                    rigidbodiesToExplode.Add(rd);

                _explosion.Explosion(rigidbodiesToExplode, position);
            }
        }
        Destroy(cube.gameObject);
    }
}
