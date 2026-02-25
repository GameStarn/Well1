using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cube cube))
        {
            cube.StartLifeTimeer();
        }

        if(other.TryGetComponent(out ColorChanger collor))
        {
            collor.SetRandomCollor();
        }
    }
}
