using TMPro;
using UnityEngine;

public class GameplayState : StateBase
{
    [SerializeField] GameObject m_gameplayPanel;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private LevelController m_levelController;
    [SerializeField] private PlayerController m_playerController;

    private GameStateMachine m_gameStateMachine;

    public override void Initialize()
    {
        m_gameStateMachine = gameStateMachine;
        m_gameplayPanel.gameObject.SetActive(false);
    }

    public override void Enter()
    {
        m_gameplayPanel.gameObject.SetActive(true);

        m_scoreManager.Reset();
        m_scoreManager.ScoreChanged += OnScoreChanged;

        OnScoreChanged(m_scoreManager.m_score);
        m_scoreText.gameObject.SetActive(true);

        m_levelController.enabled = true;
        m_playerController.enabled = true;

        m_levelController.Initialize();
        m_levelController.Finished += OnFinished;
    }

    private void OnFinished() => m_gameStateMachine.Enter<GameOverState>();

    public override void Exit()
    {
        m_levelController.enabled = false;
        m_playerController.enabled = false;
        m_scoreText.gameObject.SetActive(false);
        m_gameplayPanel.gameObject.SetActive(false);
        m_levelController.Finished -= OnFinished;
    }

    private void OnScoreChanged(int score) => m_scoreText.text = score.ToString();

}
