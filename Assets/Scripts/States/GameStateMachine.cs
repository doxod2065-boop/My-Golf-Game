using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private MainMenuState m_mainMenuState;
    [SerializeField] private GameplayState m_gameplayState;

    private void Awake()
    {
        m_mainMenuState.Initialize(this);
        m_mainMenuState.Initialize(this);
    }

    private void Start() => Enter<MainMenuState>

    public void Enter<T>()
    {
        if (typeof(T) == typeof(GameplayState))
        {
            m_gameplayState.Enter();
        }
        else if
        {
            m_bootstrapState.Exit();
            m_mainMenuState.Enter();
        }
    }
}
