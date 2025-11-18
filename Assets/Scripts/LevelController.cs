using System;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public event Action Finished;

    [SerializeField] private int m_missedCount;
    [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
    [SerializeField] private StoneSpawner m_stoneSpawner;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private ScoreManager m_scoreManager;

    private float m_time;
    private int m_currentMissedCount;
    private 

    private void Awake()
    {
        m_currentMissedCount = m_missedCount;
        m_score = 0;
        UpdateScoreUI();
    }

    private void Update()
    {
        m_time += Time.deltaTime;

        if (m_time >= m_spawnRate)
        {
            Stone stone = m_stoneSpawner.Spawn();

            stone.Hit += OnHitStone;
            stone.Missed += OnMissed;

            m_time = 0;
        }  
    }
    private void OnHitStone(Stone stone)
    {
        stone.Hit -= OnHitStone;
        stone.Missed -= OnMissed;

        m_score += 10;
        m_scoreManager.Increase();
    }

    private void OnMissed(Stone stone)
    {

        stone.Hit -= OnHitStone;
        stone.Missed -= OnMissed;

        m_currentMissedCount--;
        if (m_currentMissedCount <= 0)
        {
            Debug.Log($"Game Over! Final score: {m_score}");
        }
    }

    private void UnsubscrideStone(Stone stone)
    {
        if 
    }

    private void UpdateScoreUI()
    {
        if (m_scoreText != null)
        {
            m_scoreText.text = $"Score: {m_score}";
        }
    }
}
