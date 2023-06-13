using UnityEngine;
using DG.Tweening;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private Material _materialCar;
    [SerializeField] private Color _targetColor;

    private Color _currentColor;
    private float durationTime = 0.1f;
    private int loopCount = 2;

    private void Start()
    {
        _currentColor = _materialCar.color;
    }

    public void Change()
    {
        _materialCar.DOColor(_currentColor, 0);
        _materialCar.DOColor(_targetColor, durationTime).SetLoops(loopCount, LoopType.Yoyo);
    }
}
