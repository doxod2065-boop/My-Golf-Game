using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> ScoreChanged;
    public event Action<int> HighScoreChanged;

    public int m_score;

    public int Score
    {
        get => m_score;
        private set
        {
            m_score = value;
            Debug.Log($"Score: {value}");
            ScoreChanged?.Invoke(value);
        }
    }

    public int highScore
    {
        get => PlayerPrefs.GetInt(GlobalConstants.HighScore, 0);
        private set
        {
            if (highScore < value)
            {
                PlayerPrefs.SetInt(GlobalConstants.HighScore, value);
                HighScoreChanged?.Invoke(value);
            }
        }
    }

    public void Increase() => Score++;

    public void Increase(int amount) => Score += amount;

    public void UpdateHighScore() => highScore = Score;
    public void Reset() => Score = 0;
}
