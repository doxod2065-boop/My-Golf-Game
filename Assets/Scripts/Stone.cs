using JetBrains.Annotations;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Stone : MonoBehaviour
{
    public event Action<Stone> Hit;
    public event Action<Stone> Missed;

    [SerializeField] private bool m_isSpecialStone = false;
    [SerializeField] private int m_scoreValue = 1;
    [SerializeField] private Material m_specialMaterial;

    private Rigidbody m_rigidbody;

    public bool IsSpecial => m_isSpecialStone;
    public int ScoreValue => m_scoreValue;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        if (m_isSpecialStone && m_specialMaterial != null)
        {
            GetComponent<Renderer>().material = m_specialMaterial;
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
