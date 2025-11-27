using NUnit.Framework;
using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    public event Action Finished;

    [SerializeField] private int m_missedCount;
    [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
    [SerializeField] private StoneSpawner m_stoneSpawner;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private float m_extraDelayOnMiss = 1f;

    private float m_time;
    private int m_currentMissedCount;
    private List<Stone> m_stones;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        m_stones = new List<Stone>();
    }

    public void Initialize()
    {
        m_currentMissedCount = m_missedCount;

        if (m_stoneSpawner != null)
        {
            m_stoneSpawner.ResetToBaseChance();
        }

        if (m_scoreManager != null)
        {
            m_scoreManager.Reset();
        }
    }

    private void Update()
    {
        m_time += Time.deltaTime;

        if (m_time >= m_spawnRate)
        {
            Stone stone = m_stoneSpawner.Spawn();
            m_stones.Add(stone);

            stone.Hit += OnHitStone;
            stone.Missed += OnMissed;

            m_time = 0;
        }  
    }
    private void OnHitStone(Stone stone)
    {
        UnsubscribeStone(stone);

        if (stone.IsBlackStone)
        {
            m_scoreManager.Increase(stone.ScoreValue);
        }
        else if (stone.IsHeartStone)
        {
            m_currentMissedCount++;
        }
        else if (stone.IsSmallStone)
        {
            m_scoreManager.Increase(stone.ScoreValue);
        }
        else if (stone.IsSpecial)
        {
            m_scoreManager.Increase(stone.ScoreValue);
        }
        else
        {
            m_scoreManager.Increase();
        }
    }

    private void OnMissed(Stone stone)
    {
        UnsubscribeStone(stone);
        m_time -= m_extraDelayOnMiss;
        m_currentMissedCount--;
        if (m_currentMissedCount <= 0)
        {
            Debug.Log($"Game Over!");
            Finished?.Invoke();

            foreach (var item in m_stones)
            {
                Destroy(item.gameObject);
            }

            m_stones.Clear();
        }
    }

    private void UnsubscribeStone(Stone stone)
    {
        stone.Hit -= OnHitStone;
        stone.Missed -= OnMissed;
    }
}
