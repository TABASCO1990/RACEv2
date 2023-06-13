using TMPro;
using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _hightScoreMainMenu;
    [SerializeField] private TMP_Text _hightScoreOnGame;
    [SerializeField] float _sizeScoreText;
    [SerializeField] float _durationChangeSize;

    private int loopCount = 2;   

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
        _player.HightScoreChanged += OnHightScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
        _player.HightScoreChanged -= OnHightScoreChanged;
    }

    private void Start()
    {
        _hightScoreMainMenu.text = _player.HightScore.ToString();
        _hightScoreOnGame.text = _player.HightScore.ToString();
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();       
        transform.DOScale(_sizeScoreText, _durationChangeSize).SetLoops(loopCount, LoopType.Yoyo);
        _score.DOColor(Color.yellow, _durationChangeSize).SetLoops(loopCount, LoopType.Yoyo);
    }

    private void OnHightScoreChanged(int higthScore)
    {
        _hightScoreOnGame.text = higthScore.ToString();
    }
}
