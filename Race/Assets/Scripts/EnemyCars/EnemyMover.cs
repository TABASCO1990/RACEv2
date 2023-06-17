using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.RotateAround(transform.parent.localPosition, Vector3.up, _speed * Time.deltaTime);
    }
}
