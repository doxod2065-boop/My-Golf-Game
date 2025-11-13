using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEngine;

namespace old
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FreeCamera m_camera;
        [SerializeField] private GameObject m_uiPanel;
        [SerializeField] private CloudController m_CloudController;
        [SerializeField] private NPC_Tools_Change[] m_npcs;
        [SerializeField] private KeyCode changeItemKey = KeyCode.X;
        private void Update()
        {
            if (m_uiPanel.activeSelf)
            {
                return;
            }

            m_camera.Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_CloudController.MoveNext();
            }

            if (Input.GetKeyDown(changeItemKey))
            {
                NPC_Tools_Change.ChangeAllItemsManual(m_npcs);
            }
        }
    }
}
