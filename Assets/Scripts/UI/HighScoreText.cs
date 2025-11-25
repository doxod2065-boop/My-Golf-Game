using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class HighScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private string m_format;

    private void OnValidate()
    {
        if(!m_text)
        {
            m_text = GetComponent<TMP_Text>();
        }
    }

    private void OnEnable()
    {
        OnHighScoreChanged(m_scoreManager.Score);
        m_scoreManager.HighScoreChanged += OnHighScoreChanged;
    }

    private void OnDisable() => m_scoreManager.HighScoreChanged -= OnHighScoreChanged;

    private void OnHighScoreChanged(int value)
    {
        m_format ??= string.Empty;
        m_text.text = string.Format(m_format, value.ToString());
    }
}
