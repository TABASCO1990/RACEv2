using UnityEngine;
using DG.Tweening;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private Vector3 _vectorOffset = new Vector3(1f,1f,1f);

    private Vector3 _currentPosition;
    private float _durationTime = 0.1f;
    private int _loopCount = 2;
    private int _strengthShake = 5;

    private void Start()
    {
        _currentPosition = _mainCamera.position;
    }

    public void Shake()
    {
        DOTween.Kill(_mainCamera);
        _mainCamera.position = _currentPosition;
        _mainCamera.DOShakePosition(_durationTime, _vectorOffset, _strengthShake).SetLoops(_loopCount, LoopType.Yoyo);
    }
}
