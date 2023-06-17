using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _score;
    private int _hightScore;
    private string _saveScore = "SaveScore";

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HightScoreChanged;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    public int HightScore => _hightScore;

    private void Awake()
    {       
        _hightScore = PlayerPrefs.GetInt(_saveScore);
    }

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
        SetHightScore();
        ScoreChanged?.Invoke(_score);
    }

    private void Die()
    {
        Died?.Invoke();
    }

    private void SetHightScore()
    {
        if(_score > _hightScore)
        {
            _hightScore = _score;

            PlayerPrefs.SetInt(_saveScore, _hightScore);
            HightScoreChanged?.Invoke(_hightScore);
        }
    }
}
