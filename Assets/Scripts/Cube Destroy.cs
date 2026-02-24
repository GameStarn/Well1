using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroy : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cube cube))
        {
            cube.StartLifeTimeer();
        }

        if(other.TryGetComponent(out CubeCollor collor))
        {
            collor.SetRandomCollor();
        }
    }
}
