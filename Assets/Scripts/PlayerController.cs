using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Club m_club;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_club.Down();
        }
        else 
        {
            m_club.Up();
        }
    }
}
