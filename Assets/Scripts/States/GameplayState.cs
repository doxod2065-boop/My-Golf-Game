using TMPro;
using UnityEngine;

public class GameplayState : StateBase
{
    [SerializeField] GameObject m_gameplayPanel;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private LevelController m_levelController;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private CharacterMaterial m_characterMaterial;

    private GameStateMachine m_gameStateMachine;

    public override void Initialize(GameStateMachine gameStateMachine)
    {
        m_gameplayPanel.SetActive(false);
        m_gameStateMachine = gameStateMachine;

        if (m_characterMaterial == null)
        {
            m_characterMaterial = FindAnyObjectByType<CharacterMaterial>();
        }
    }

    public override void Enter()
    {
        AudioManager.Instance.PlayGameplayMusic();

        m_characterMaterial.ApplyRandomCharacterMaterial();
        m_scoreManager.Reset();
        m_scoreManager.ScoreChanged += OnScoreChanged;

        OnScoreChanged(m_scoreManager.m_score);
        m_gameplayPanel.SetActive(true);

        m_levelController.enabled = true;
        m_playerController.enabled = true;

        m_levelController.Initialize();
        m_levelController.Finished += OnFinished;
    }

    private void OnFinished() => m_gameStateMachine.Enter<GameOverState>();

    public override void Exit()
    {
        AudioManager.Instance.StopMusic();
        m_gameplayPanel.SetActive(false);
        m_levelController.enabled = false;
        m_playerController.enabled = false;
        m_levelController.Finished -= OnFinished;
    }

    private void OnScoreChanged(int score) => m_scoreText.text = score.ToString();
}
