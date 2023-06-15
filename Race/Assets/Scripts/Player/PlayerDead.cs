using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] private UnityEvent _spentLives;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died += OnDied;
    }

    private void OnDied()
    {
        _spentLives?.Invoke();
    }
}
