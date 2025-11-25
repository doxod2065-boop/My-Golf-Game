using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : StateBase
{
    [SerializeField] private Button m_playButton;
    [SerializeField] private GameObject m_mainMenuRoot;

    private GameStateMachine m_gameStateMachine;

    public override void Initialize(GameStateMachine gameStateMachine)
    {
        m_mainMenuRoot.SetActive(false);
        m_gameStateMachine = gameStateMachine;
    }

    public override void Enter()
    {
        AudioManager.Instance.PlayMainMenuMusic();
        m_mainMenuRoot.SetActive(true);
        m_playButton.onClick.AddListener(OnClicked);
    }

    public override void Exit()
    {
        m_mainMenuRoot.SetActive(false);
        m_playButton.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        m_gameStateMachine.Enter<GameplayState>();
    }
}
