using UnityEngine;
using DG.Tweening;

public class AudioSetter : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _targetPitch;
    
    private float _currentPitch;
    private float _duration = 1f;
    private bool _isActiveSpeed;

    private void Start()
    {
        _currentPitch = _audioSource.pitch;
    }

    public void SetPitch(bool acteveSpeed)
    {
        _isActiveSpeed = acteveSpeed;
        if (_isActiveSpeed)
        {
            _audioSource.DOPitch(_targetPitch, _duration);
        }
        else
        {
            _audioSource.DOPitch(_currentPitch, _duration);
        }
    }
}
