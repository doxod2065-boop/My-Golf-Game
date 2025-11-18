using UnityEngine;

public class GameplayState : MonoBehaviour
{
    [SerializeField] private 
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private LevelController m_levelController;
    [SerializeField] private PlayerController m_playerController;

    private GameStateMachine m_gameStateMachine;

public void Initialize(GameStateMachine gameStateMachine)
    {
        m_gameStateMachine = gameStateMachine
    }

    public void Enter()
    {
        m_scoreManager.Reset();

        m_scoreText

        m_levelController.enabled = true;
        m_playerController.enabled = true;
    }

    public void Exit()
    {

    }
}
