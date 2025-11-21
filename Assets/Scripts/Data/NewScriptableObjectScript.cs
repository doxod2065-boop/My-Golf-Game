using UnityEngine;

[CreateAssetMenu(fileName = "NewStoneData", menuName = "Scriptable Objects/StoneData")]
public class StoneData : ScriptableObject
{
    [SerializeField] private int m_score;

    public int score => m_score;
}
