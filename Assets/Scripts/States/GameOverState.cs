using UnityEngine;

public class GameOverState : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOverPanel;

    private GameStateMachine m_gameStateMachine;

    public void Initialize(GameStateMachine gameStateMachine)
    {

    }

    public void Enter()
    {
        m_gameOverPanel.gameObject.SetActive(true);
        m_gameOverPanel.onClick.AddListener(OnClick);
        m_gameOverPanel.gameObject.SetActive(true);
    }

    public void Exit()
    {
        m_gameOverPanel.gameObject.SetActive(false);
    }

    private void OnClicked() => m_gameStateMachine
}
