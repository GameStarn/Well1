using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollor : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] private Material _material1;
    [SerializeField] private Material _material2;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetRandomCollor()
    {
        _renderer.material = _material1;
    }

    public void ResetColor()
    {
        _renderer.material = _material2;
    }
}
