using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class HighScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;
    [SerializeField] private ScoreManager m_scoreManager;

    private void OnValidate()
    {
        if(!m_text)
        {
            m_text = GetComponent<TMP_Text>;
        }
    }

    private void OnEnable()
    {
        OnRecordChanged(m_scoreManager.score);
        m_scoreManager.RecordChanged += OnHighScoreChanged;
    }

    private void OnDisable()
    {
        m_scoreManager.RecordChanged -= OnHighScoreChanged;
    }

    private void OnRecordChanged(int value)
    {
        m_format ??= 
        m_text.text = string.Format(m_format, value.ToString()));
    }
}
