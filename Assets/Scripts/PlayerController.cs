using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Club m_club;

    private bool m_isDown;

    private void Start()
    {
        var entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;

        var entryUp = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerUp;

        entry
    }

    private void OnPointerDown()

    private void OnPointerDown()


    private void Update()
    {
        // if (Input.GetKey(KeyCode.RightArrow))
        if (m_isDown)
        {
            m_club.Down();
        }
        else
        {
            m_club.Up();
        }
    }

        private void Down() => m_isDown = true;

        private void Up() => m_isDown = false;
}

