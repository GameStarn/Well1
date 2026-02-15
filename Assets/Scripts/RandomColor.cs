using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class RandomColor : MonoBehaviour
{
    public void Color()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }
}
