using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubedestroy : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField, Range(0f, 100f)] private float chance = 100f;

    [SerializeField] private float explosionForce = 5f;
    [SerializeField] private float explosionRadius = 2f;
    [SerializeField] private float upwardModifier = 0.5f;

    private void OnEnable()
    {
        Pressingdetector.OnCubeClicked += CubeSpawn;
    }

    private void OnDisable()
    {
        Pressingdetector.OnCubeClicked -= CubeSpawn;
    }

    private void CubeSpawn(GameObject clickedObject)
    {
        if (clickedObject != gameObject) return;

        float roll = Random.Range(0f, 100f);
        if(roll > chance)
        {
            Destroy(gameObject); return;
        }

        int count = Random.Range(2, 7);

        for (int i = 0; i < count; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);

            newCube.transform.localScale = transform.localScale * 0.5f;
            newCube.GetComponent<Cubedestroy>().chance = this.chance / 2f;
            Renderer renderer = newCube.GetComponent<Renderer>();
            renderer.material.color = Random.ColorHSV();
            Rigidbody rigidbody = newCube.GetComponent<Rigidbody>();
            if (rigidbody != null )
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardModifier, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
