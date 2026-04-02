using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomDirection : MonoBehaviour
{
    public Vector3 GetRandomDirection()
    {
        float randomY = Random.Range(0f, 360f);
        Quaternion rotation =  Quaternion.Euler(0, randomY, 0);

        return rotation * Vector3.forward;
    }
}