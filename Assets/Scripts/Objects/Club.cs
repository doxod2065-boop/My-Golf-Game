using System;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Club : MonoBehaviour
{
    [SerializeField, Min(0)] private float m_power = 250;
    [SerializeField] private Transform m_point;
    [SerializeField] private float m_minAngleZ = -30;
    [SerializeField] private float m_maxAngleZ = 30;
    [SerializeField] private float m_speed;

    [SerializeField] private AudioClip m_hitSound;
    [SerializeField] private float m_minVolume = 0.3f;
    [SerializeField] private float m_maxVolume = 1.0f;
    [SerializeField] private float m_minPitch = 0.8f;
    [SerializeField] private float m_maxPitch = 1.2f;

    private Vector3 m_direction;
    private Vector3 m_lastPointPosition;
    private bool m_isDown;
    private AudioSource m_audioSource;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        if (m_audioSource == null)
        {
            m_audioSource = gameObject.AddComponent<AudioSource>();
        }

        SetupAudioSource();
    }

    private void SetupAudioSource()
    {
        m_audioSource.playOnAwake = false;
        m_audioSource.spatialBlend = 1.0f;
        m_audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        m_audioSource.maxDistance = 20f;
    }

    private void FixedUpdate()
    {
        var angles = transform.localEulerAngles;

        if (m_isDown)
        {
            angles.z = Rotate(angles.z, m_minAngleZ);
        }
        else
        {
            angles.z = Rotate(angles.z, m_maxAngleZ);
        }

        transform.localEulerAngles = angles;

        m_direction = (m_point.position - m_lastPointPosition).normalized;
        m_lastPointPosition = m_point.position;

        m_isDown = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (this == null || gameObject == null) return;

        if (other.gameObject.TryGetComponent<Stone>(out var stone))
        {
            stone.AddForce(m_power * m_direction);

            PlayHitSound();
        }
    }

    private void PlayHitSound()
    {
        if (m_hitSound != null && m_audioSource != null)
        {
            m_audioSource.volume = UnityEngine.Random.Range(m_minVolume, m_maxVolume);
            m_audioSource.pitch = UnityEngine.Random.Range(m_minPitch, m_maxPitch);

            m_audioSource.PlayOneShot(m_hitSound);
        }
    }

    private float Rotate(float angleZ, float target)
    {
        return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.deltaTime);
    }

    public void Down() => m_isDown = true;
    public void Up() => m_isDown = false;
}
