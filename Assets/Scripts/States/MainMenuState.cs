using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : StateBase
{
    [SerializeField] private Button m_playButton;
    [SerializeField] private GameObject m_mainMenuRoot;

    private GameStateMachine m_gameStateMachine;

    public override Initialize(GameStateMachine gameStateMachine)
    {
        m_mainMenuRoot.SetActive(false);
        m_gameStateMachine = gameStateMachine;
    }

    public override Enter()
    {
        m_mainMenuRoot.SetActive(true);
        m_playButton.onClick.AddListener(OnClicked);
    }

    public override Exit()
    {
        m_mainMenuRoot.SetActive(false);
        m_playButton.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        m_gameStateMachine.Enter<GameplayState>();
    }
}
