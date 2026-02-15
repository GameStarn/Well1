using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    [SerializeField] private CubeExplosion _explosion;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private InputRaycaster _inputRaycaster;

    private void Start()
    {
        _inputRaycaster.OnCubeClicked += HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube cube)
    {
        Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

        _spawner.Spawn(cube.transform.position, cube.transform.localScale, cube.Chance, _explosion);

        _explosion.Explosion(rigidbody, cube.transform.position);

        Destroy(cube.gameObject);
    }

    private void OnDestroy()
    {
        _inputRaycaster.OnCubeClicked += HandleCubeClicked;
    }
}
