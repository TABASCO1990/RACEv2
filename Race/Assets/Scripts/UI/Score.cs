using TMPro;
using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private AudioClip _clip;
    [SerializeField] float _sizeScoreText;
    [SerializeField] float _durationChangeSize;

    private int loopCount = 2;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
        transform.DOScale(_sizeScoreText, _durationChangeSize).SetLoops(loopCount, LoopType.Yoyo);
        _score.DOColor(Color.yellow, _durationChangeSize).SetLoops(loopCount, LoopType.Yoyo);
    }
}
