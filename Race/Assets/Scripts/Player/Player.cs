using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Material _materialCar;

    private int _score;
    private Material _currentMaterial;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        _currentMaterial = _materialCar;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;        
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            
            Die();
        }
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        _materialCar = _currentMaterial;
        print("сдох");
    }
}
