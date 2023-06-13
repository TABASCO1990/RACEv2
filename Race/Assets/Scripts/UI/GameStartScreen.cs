using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private Button _playButton;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void Start()
    {
        Time.timeScale = 0;       
    }

    private void OnDied()
    {
        StartCoroutine(GameOver());
    }

    private void OnPlayButtonClick()
    {
        Time.timeScale = 1;
        _startPanel.SetActive(false);
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
