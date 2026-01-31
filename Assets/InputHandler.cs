using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action OnClickDetecten;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnClickDetecten.Invoke();
        }
    }
}