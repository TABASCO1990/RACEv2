using TMPro;
using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _hightScore;
    [SerializeField] float _sizeScoreText;
    [SerializeField] float _durationChangeSize;

    private int loopCount = 2;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
        _player.ScoreChanged += OnHightScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
        _player.ScoreChanged -= OnHightScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();       
        transform.DOScale(_sizeScoreText, _durationChangeSize).SetLoops(loopCount, LoopType.Yoyo);
        _score.DOColor(Color.yellow, _durationChangeSize).SetLoops(loopCount, LoopType.Yoyo);
    }

    private void OnHightScoreChanged(int higthScore)
    {
        _hightScore.text = higthScore.ToString();
    }
}
