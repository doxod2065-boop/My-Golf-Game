using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverState : StateBase
{
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private Button m_backGameMenu;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private GameObject m_gameOverPanel;

    private GameStateMachine m_gameStateMachine;

    public override void Initialize(GameStateMachine gameStateMachine)
    {
        m_gameStateMachine = gameStateMachine;
        m_gameOverPanel.gameObject.SetActive(false);
    }

    public override void Enter()
    {
        m_scoreText.text = m_scoreManager.m_score.ToString();
        m_scoreManager.UpdateHighScore();
        m_backGameMenu.onClick.AddListener(OnClicked);
        m_gameOverPanel.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        m_gameOverPanel.gameObject.SetActive(false);
    }

    private void OnClicked() => m_gameStateMachine.Enter<MainMenuState>();
}
