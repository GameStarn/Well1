using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;

    public event System.Action<Cube> CubeClicked;

    private void OnEnable()
    {
        if (_userInput != null)
            _userInput.Click += HandleClick;
    }

    private void OnDisable()
    {
        if (_userInput != null)
            _userInput.Click -= HandleClick;
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray , out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                CubeClicked?.Invoke(cube);
            }
        }
    }
}
