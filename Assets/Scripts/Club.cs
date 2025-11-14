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

    private Vector3 m_direction;
    private Vector3 m_lastPointPosition;

    private void FixedUpdate()
    {
        Application.targetFrameRate = 30;

        var angles = transform.localEulerAngles;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            angles.z = Rotate(angles.z, m_minAngleZ);
        }
        else
        {
            angles.z = Rotate(angles.z, m_maxAngleZ);
        }

        transform.localEulerAngles = angles;

        var direction = m_point.position - m_lastPointPosition;
        m_lastPointPosition = m_point.position;
    }

        private float Rotate(float angleZ, float target)
        {
        return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.deltaTime);
        }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Stone>(out var stone))
        {
            stone.GetComponent<Rigidbody>().AddForce(m_power * m_direction, ForceMode.Force);
        }
    }
}
