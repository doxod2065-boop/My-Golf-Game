using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private Button m_backGameMenu;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private GameObject m_gameOverPanel;

    private GameStateMachine m_gameStateMachine;

    public void Initialize(GameStateMachine gameStateMachine)
    {
        m_gameStateMachine = gameStateMachine;
        m_gameOverPanel.gameObject.SetActive(false);
    }

    public void Enter()
    {
        m_scoreText.text = m_scoreManager.m_score.ToString();
        m_backGameMenu.onClick.AddListener(OnClicked);
        m_gameOverPanel.gameObject.SetActive(true);
    }

    public void Exit()
    {
        m_gameOverPanel.gameObject.SetActive(false);
    }

    private void OnClicked() => m_gameStateMachine.Enter<MainMenuState>();
}
