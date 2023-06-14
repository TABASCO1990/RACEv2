using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakePosition : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private Vector3 _strengthShake = new Vector3(1f,1f,1f);

    private Transform _currentPosition;
    private float _durationTime = 0.1f;
    private int _loopCount = 2;
    private int _strengthVibrato = 5;

    private void Start()
    {
        _currentPosition = _mainCamera;
    }

    public void Shake()
    {    
        //_mainCamera.DOShakePosition(0,)
        _mainCamera.DOShakePosition(_durationTime, _strengthShake, _strengthVibrato).SetLoops(_loopCount, LoopType.Yoyo);
    }
}
