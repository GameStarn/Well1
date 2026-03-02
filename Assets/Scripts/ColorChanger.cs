using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _primaryMaterial;
    [SerializeField] private Material _changedMaterial;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        _renderer.material = _primaryMaterial;
    }

    public void ResetColor()
    {
        _renderer.material = _changedMaterial;
    }
}
