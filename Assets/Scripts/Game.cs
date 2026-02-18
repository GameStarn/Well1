using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Raycaster _Raycaster;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExplosion _explosion;
    [SerializeField] private RandomColor _color;
    [SerializeField] private CubeChance _chance;

    private void Start()
    {
        _Raycaster.OnCubeClicked += HandleCubeClicked;
    }
    private void OnDestroy()
    {
        _Raycaster.OnCubeClicked -= HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube cube)
    {
        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;
        float chanse = cube.Chance;

        if (cube.TryGetComponent(out Rigidbody oldRb))
        {
            _explosion.Explosion(oldRb, position);
        }

        if (_chance.ShouldSpawn(chanse))
        {
            List<GameObject> newCubes = _spawner.Spawn(position, scale, chanse);

            foreach (GameObject newCube in newCubes)
            {
                if (newCube.TryGetComponent(out RandomColor newColor))
                {
                    newColor.Color();
                }

                if (newCube.TryGetComponent(out Rigidbody rigidbody))
                {
                    _explosion.Explosion(rigidbody, position);
                }
            }
        }

        Destroy(cube.gameObject);
    }
}
