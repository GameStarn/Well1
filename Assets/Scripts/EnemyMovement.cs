using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector3 _direction;

    public void Init(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    public void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
}