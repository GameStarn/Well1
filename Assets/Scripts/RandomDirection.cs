using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomDirection : MonoBehaviour
{
    public Quaternion GetRandomRotation()
    {
        float randomY = Random.Range(0f, 360f);
        return Quaternion.Euler(0, randomY, 0);
    }
}