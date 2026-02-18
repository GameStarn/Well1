using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public event System.Action<Cube> OnCubeClicked;

    [SerializeField] private UserInput _userInput;

    private void OnEnable()
    {
        if (_userInput != null)
            _userInput.OnClick += HandleClick;
    }

    private void OnDisable()
    {
        if (_userInput != null)
            _userInput.OnClick -= HandleClick;
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray , out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                OnCubeClicked?.Invoke(cube);
            }
        }
    }
}
