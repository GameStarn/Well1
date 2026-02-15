using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRaycaster : MonoBehaviour
{
    public event System.Action<Cube> OnCubeClicked;
    private RaycastHit _hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                Cube cube = _hit.collider.GetComponent<Cube>();

                if (cube != null)
                {
                    OnCubeClicked?.Invoke(cube);
                }
            }
        }
    }
}
