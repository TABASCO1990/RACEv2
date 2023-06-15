using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _reachedPoint;
    [SerializeField] private UnityEvent _reachedObstacle;

    private Player _player;

    private void Start()
    {       
        _player = GetComponent<Player>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out ScoreZone zone))
        {
            _player.IncreaseScore();
            _reachedPoint?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.TryGetComponent(out Enemy enemyCar))
        {              
            _reachedObstacle?.Invoke();         
        }
    }
}
