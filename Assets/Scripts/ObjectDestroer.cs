using UnityEngine;

public class ObjectDestroer : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 10f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}