using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_mainMenuMusic;
    [SerializeField] private AudioClip m_gameplayMusic;
    [SerializeField] private float m_volume = 0.5f;

    private AudioSource m_audioSource;
    private static AudioManager m_instance;

    public static AudioManager Instance => m_instance;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        m_audioSource = GetComponent<AudioSource>();
        SetupAudioSource();
    }

    private void SetupAudioSource()
    {
        m_audioSource.volume = m_volume;
        m_audioSource.loop = true;
        m_audioSource.playOnAwake = false;
    }

    public void PlayMainMenuMusic()
    {
        if (m_mainMenuMusic != null)
        {
            m_audioSource.clip = m_mainMenuMusic;
            m_audioSource.Play();
        }
    }

    public void PlayGameplayMusic()
    {
        if (m_gameplayMusic != null)
        {
            m_audioSource.clip = m_gameplayMusic;
            m_audioSource.Play();
        }
    }

    public void StopMusic()
    {
        m_audioSource.Stop();
    }

    public void SetVolume(float volume)
    {
        m_volume = Mathf.Clamp01(volume);
        m_audioSource.volume = m_volume;
    }
}
