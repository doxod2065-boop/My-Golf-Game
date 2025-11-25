using UnityEngine;
using System.Collections.Generic;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private Stone[] m_commonStones;
    [SerializeField] private Stone m_specialStone;
    [SerializeField] private Stone m_blackStone;
    [SerializeField] private Stone m_smallStone;
    [SerializeField] private Stone m_heartStone;
    [SerializeField] private Stone m_bombStone;

    [SerializeField] private Transform m_spawnPoint;
    [SerializeField][Range(0, 1)] private float m_baseSpecialStoneChance = 0.01f;
    [SerializeField][Range(0, 1)] private float m_blackStoneChance = 0.25f;
    [SerializeField][Range(0, 1)] private float m_smallStoneChance = 0.15f;
    [SerializeField][Range(0, 1)] private float m_heartStoneChance = 0.05f;
    [SerializeField][Range(0, 1)] private float m_bombStoneChance = 0.08f;
    [SerializeField][Range(0, 1)] private float m_chanceIncrease = 0.05f;

    private float m_currentSpecialStoneChance;
    private ScoreManager m_scoreManager;
    private int m_currentScore = 0;

    private void Start()
    {
        m_scoreManager = FindAnyObjectByType<ScoreManager>();
        if (m_scoreManager != null)
        {
            m_scoreManager.ScoreChanged += OnScoreChanged;
        }

        ResetSpecialStoneChance();
    }

    public Stone Spawn()
    {
        Stone stoneToSpawn = ChooseStoneToSpawn();
        if (stoneToSpawn != null)
        {
            stoneToSpawn = Instantiate(stoneToSpawn, m_spawnPoint.position, m_spawnPoint.rotation);
        }
        return stoneToSpawn;
    }

    private Stone ChooseStoneToSpawn()
    {
        float randomValue = Random.Range(0f, 1f);

        if (m_currentScore >= 20 && randomValue <= m_bombStoneChance && m_bombStone != null)
        {
            return m_bombStone;
        }

        if (m_currentScore >= 20 && randomValue <= m_heartStoneChance && m_heartStone != null)
        {
            return m_heartStone;
        }

        if (m_currentScore >= 10 && randomValue <= m_blackStoneChance && m_blackStone != null)
        {
            return m_blackStone;
        }

        if (m_currentScore >= 10 && randomValue <= m_smallStoneChance && m_smallStone != null)
        {
            return m_smallStone;
        }

        if (randomValue <= m_currentSpecialStoneChance && m_specialStone != null)
        {
            ResetSpecialStoneChance();
            return m_specialStone;
        }

        IncreaseSpecialStoneChance();
        return GetRandomCommonStone();
    }

    private Stone GetRandomCommonStone()
    {
        if (m_commonStones == null || m_commonStones.Length == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, m_commonStones.Length);
        return m_commonStones[randomIndex];
    }

    private void IncreaseSpecialStoneChance() => m_currentSpecialStoneChance = Mathf.Min(1f, m_currentSpecialStoneChance + m_chanceIncrease);

    private void ResetSpecialStoneChance() => m_currentSpecialStoneChance = m_baseSpecialStoneChance;

    public void ResetToBaseChance() => ResetSpecialStoneChance();

    private void OnScoreChanged(int newScore) => m_currentScore = newScore;
}