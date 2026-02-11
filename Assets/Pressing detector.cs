using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressingdetector : MonoBehaviour
{
    public static event System.Action<GameObject> OnCubeClicked;
    private RaycastHit hit;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit))
            {
                OnCubeClicked?.Invoke(hit.collider.gameObject);

            }
        }
    }
}
