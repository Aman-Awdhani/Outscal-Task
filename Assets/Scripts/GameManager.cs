
using UnityEngine;
using System;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Action onLevelFailedEvent;

    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _startButton;

    bool isGameStarted;
    bool isGameEnded;


    private void Awake()
    {
        instance = this;
        _playAgainButton.onClick.AddListener(PlayAgain);
        _startButton.onClick.AddListener(GameStart);

    }

    internal bool IsGameRunning() => isGameStarted && !isGameEnded;

    internal void LevelFailed()
    {
        isGameEnded = true;

        if (onLevelFailedEvent != null)
            onLevelFailedEvent();
    }

    internal void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    internal void GameStart()
    {
        isGameStarted = true;
    }
}
