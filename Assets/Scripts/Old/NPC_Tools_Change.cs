using UnityEngine;

public class NPC_Tools_Change : MonoBehaviour
{
    [SerializeField] private GameObject[] m_itemPrefabs;
    [SerializeField] private Transform m_holdPoint;
    [SerializeField] private Animator m_NPCAnimator;
    [SerializeField] private string m_animationTrigger = "VillagerFREE@Farming";
    [SerializeField] private GameObject m_initialItem;

    private GameObject m_currentItem;
    private int m_currentItemIndex = 0;

    private void Start()
    {
        if (m_initialItem != null) // Отключаем изначальный предмет через инспектор
        {
            Renderer initialRenderer = m_initialItem.GetComponent<Renderer>();
            if (initialRenderer != null)
            {
                initialRenderer.enabled = false;
            }
        }

        if (m_itemPrefabs.Length > 0)
        {
            EquipItem(0);
        }
    }

    public static void ChangeAllItemsManual(NPC_Tools_Change[] npcs)
    {
        foreach (NPC_Tools_Change npc in npcs)
        {
            if (npc != null)
            {
                npc.ChangeToNextItem();
            }
        }
    }

    public void ChangeToNextItem()
    {

        if (m_itemPrefabs == null || m_itemPrefabs.Length <= 1) return;

        m_currentItemIndex = (m_currentItemIndex + 1) % m_itemPrefabs.Length;
        EquipItem(m_currentItemIndex);
        PlayAnimation();
    }

    private void EquipItem(int itemIndex)
    {
        if (m_currentItem != null)
        {
            DestroyImmediate(m_currentItem);
            m_currentItem = null;
        }

        if (itemIndex < 0 || itemIndex >= m_itemPrefabs.Length) return;
        if (m_itemPrefabs[itemIndex] == null || m_holdPoint == null) return;

        m_currentItem = Instantiate(m_itemPrefabs[itemIndex], m_holdPoint);
        m_currentItem.transform.localPosition = Vector3.zero;
        m_currentItem.transform.localRotation = Quaternion.identity;
    }

    private void PlayAnimation()
    {
        if (m_NPCAnimator == null || m_NPCAnimator.gameObject == null) return;

        if (!string.IsNullOrEmpty(m_animationTrigger))
        {
            m_NPCAnimator.SetTrigger(m_animationTrigger);
        }
    }
}
