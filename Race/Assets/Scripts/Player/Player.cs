using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _score;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
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
        Died?.Invoke();
        print("сдох");
    }
}
