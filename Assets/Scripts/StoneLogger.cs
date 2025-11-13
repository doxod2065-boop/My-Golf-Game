using UnityEngine;

public class StoneLogger : MonoBehaviour
{
    [SerializeField] private string m_groundTag = "Ground"; //назначаем теги
    [SerializeField] private string m_clubTag = "Club";

    private void OnCollisionEnter(Collision collision)
    {
        string m_collidedTag = collision.gameObject.tag; // Получаем тег объекта

        if (m_collidedTag == m_groundTag) // Проверяем столкновение с полем
        {
            Debug.Log($"Камень столкнулся с землей! Объект: {collision.gameObject.name}");
        }
        else if (m_collidedTag == m_clubTag) // Проверяем столкновение с клюшкой
        {
            Debug.Log($"Камень столкнулся с клюшкой! Объект: {collision.gameObject.name}");
        }
    }
}
