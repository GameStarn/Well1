using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public event System.Action Click;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click?.Invoke();
        }
    }
}
