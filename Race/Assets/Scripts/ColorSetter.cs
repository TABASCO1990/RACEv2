using UnityEngine;
using DG.Tweening;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private Material _materialCar;
    [SerializeField] private Color _targetColor;

    private Color _currentColor;
    private float durationTime = 0.2f;
    private int loopCount = 2;

    private void Start()
    {
        _currentColor = _materialCar.color;
    }

    public void Change()
    {
        DOTween.Kill(_materialCar);
        _materialCar.color = _currentColor;
        _materialCar.DOColor(_targetColor, durationTime).SetLoops(loopCount, LoopType.Yoyo);
    }
}
