using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stone : MonoBehaviour
{
    public event Action<Stone> Hit;
    public event Action<Stone> Missed;

    [SerializeField] private bool m_isSpecialStone = false;
    [SerializeField] private bool m_isBlackStone = false;
    [SerializeField] private bool m_isSmallStone = false;
    [SerializeField] private bool m_isHeartStone = false;
    [SerializeField] private bool m_isBombStone = false;
    [SerializeField] private int m_scoreValue = 1;
    [SerializeField] private Material m_specialMaterial;
    [SerializeField] private Material m_blackStoneMaterial;
    [SerializeField] private Material m_smallStoneMaterial;
    [SerializeField] private Material m_heartStoneMaterial;
    [SerializeField] private Material m_bombStoneMaterial;

    private Rigidbody m_rigidbody;
    private Renderer m_renderer;

    public bool IsSpecial => m_isSpecialStone;
    public bool IsBlackStone => m_isBlackStone;
    public bool IsSmallStone => m_isSmallStone;
    public bool IsHeartStone => m_isHeartStone;
    public bool IsBombStone => m_isBombStone;
    public int ScoreValue => m_scoreValue;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        m_renderer = GetComponent<Renderer>();
        if (m_renderer == null)
        {
            m_renderer = GetComponentInChildren<Renderer>();
        }

        ApplyStoneSettings();
    }

    private void ApplyStoneSettings()
    {
        if (m_renderer == null)
        {
            Debug.LogWarning($"No Renderer found on {gameObject.name}! Cannot apply materials.");
            return;
        }

        Material materialToApply = null;

        if (m_isSpecialStone && m_specialMaterial != null)
        {
            materialToApply = m_specialMaterial;
        }
        else if (m_isBlackStone && m_blackStoneMaterial != null)
        {
            materialToApply = m_blackStoneMaterial;
        }
        else if (m_isSmallStone && m_smallStoneMaterial != null)
        {
            materialToApply = m_smallStoneMaterial;
        }
        else if (m_isHeartStone && m_heartStoneMaterial != null)
        {
            materialToApply = m_heartStoneMaterial;
        }
        else if (m_isBombStone && m_bombStoneMaterial != null)
        {
            materialToApply = m_bombStoneMaterial;
        }

        if (materialToApply != null)
        {
            m_renderer.material = materialToApply;
        }

        if (m_isSmallStone)
        {
            transform.localScale = Vector3.one * 0.5f;
            m_rigidbody.mass = 0.5f;
        }

        if (m_isBombStone)
        {
            transform.localScale = Vector3.one * 1.2f;
            m_rigidbody.mass = 2f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Club>())
        {
            Hit?.Invoke(this);
        }
        else
        {
            Missed?.Invoke(this);
        }
    }

    public void AddForce(Vector3 power) => m_rigidbody.AddForce(power, ForceMode.Force);
}