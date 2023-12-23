using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FBScore : MonoBehaviour
{
    public static FBScore instance;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highestScore;

    private int _score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        _currentScore.text = _score.ToString();
        _highestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }
    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highestScore.text = _score.ToString();
        }
    }
    public void UpdateScore()
    {
        _score++;
        _currentScore.text = _score.ToString();
        UpdateHighScore();
    }
}
