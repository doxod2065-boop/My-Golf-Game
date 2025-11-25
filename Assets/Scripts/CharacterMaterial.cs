using UnityEngine;

public class CharacterMaterial : MonoBehaviour

{
    [SerializeField] private Material[] m_characterMaterials;
    [SerializeField] private Renderer m_characterRenderer;

    private void Awake()
    {
        if (m_characterRenderer == null)
        {
            m_characterRenderer = GetComponent<Renderer>();
            if (m_characterRenderer == null)
            {
                m_characterRenderer = GetComponentInChildren<Renderer>();
            }
        }
    }

    public void ApplyRandomCharacterMaterial()
    {
        if (m_characterMaterials != null && m_characterMaterials.Length > 0 && m_characterRenderer != null)
        {
            Material randomMaterial = m_characterMaterials[Random.Range(0, m_characterMaterials.Length)];
            m_characterRenderer.material = randomMaterial;
        }
    }
}
