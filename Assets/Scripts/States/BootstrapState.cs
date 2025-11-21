using UnityEngine;

public class BootstrapState : StateBase
{
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private LevelController m_levelController;

    private GameStateMachine m_gameStateMachine;
    public override Initialize(GameStateMachine gameStateMachine)
    {
        m_playerController.enabled = false;
        m_levelController.enabled = false;

        m_gameStateMachine = gameStateMachine;
    }

    public override Enter()
    {
        m_gameStateMachine.Enter<MainMenuState>();
    }

    public override Exit()
    {

    }
}
