using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> ScoreChanged;
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

    public void Increase() => Score++;

    public void Increase(int amount) => Score += amount;

    public void Reset() => Score = 0;
}
