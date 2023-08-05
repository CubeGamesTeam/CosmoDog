using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private int _score;
    public int score => this._score;
    [SerializeField] private int _finalScore;
    public int finalScore => this._finalScore;
    [SerializeField] private int _recordScore;
    public int recordScore => this._recordScore;

    [SerializeField] private int maxScore;

    [SerializeField] private BoxCollider2D scoreCollider;

    public Action<int> onScoreChanged;

    [SerializeField] private string LeaderboardName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    private void Start()
    {
        _recordScore = YandexGame.savesData.scores;
        Player.Instance.onGameOver += GameOverScore;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (_score < maxScore)
            {
                _score++;
            }
            else
            {
                //Вы прошли игру!
            }
            onScoreChanged?.Invoke(_score);
        }
    }

    public void AddScore(int adding)
    {
        if (_score < maxScore)
        {
            _score += adding;
        }
        else
        {
            //Вы прошли игру!
        }
        onScoreChanged?.Invoke(_score);
    }

    private void GameOverScore()
    {
        scoreCollider.enabled = false;
        _finalScore = _score;
        if(_finalScore > _recordScore)
        {
            _recordScore = _finalScore;

            YandexGame.savesData.scores = _recordScore;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores(LeaderboardName, _recordScore);
        }
    }
}
