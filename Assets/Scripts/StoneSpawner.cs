using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private Stone[] m_prefabs;
    [SerializeField] private Stone m_specialStone;
    [SerializeField] private Transform m_spawnPoint;
    [SerializeField][Range(0, 1)] private float m_baseSpecialStoneChance = 0.2f;
    [SerializeField][Range(0, 1)] private float m_chanceIncrease = 0.05f;

    private float m_currentSpecialStoneChance;

    private void Start()
    {
        ResetSpecialStoneChance();
    }

    public Stone Spawn()
    {
        Stone spawnedStone;

        if (ShouldSpawnSpecialStone())
        {
            spawnedStone = Instantiate(m_specialStone, m_spawnPoint.position, m_spawnPoint.rotation);
            ResetSpecialStoneChance();
        }
        else
        {
            var prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
            spawnedStone = Instantiate(prefab, m_spawnPoint.position, m_spawnPoint.rotation);
            IncreaseSpecialStoneChance();
        }

        return spawnedStone;
    }

    private bool ShouldSpawnSpecialStone()
    {
        if (m_specialStone == null) return false;
        return Random.Range(0f, 1f) <= m_currentSpecialStoneChance;
    }

    private void IncreaseSpecialStoneChance() => m_currentSpecialStoneChance = Mathf.Min(1f, m_currentSpecialStoneChance + m_chanceIncrease);

    private void ResetSpecialStoneChance() => m_currentSpecialStoneChance = m_baseSpecialStoneChance;

    public void ResetToBaseChance() => ResetSpecialStoneChance();
}
