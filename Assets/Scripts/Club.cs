using System.Runtime.CompilerServices;
using UnityEngine;

public class Club : MonoBehaviour
{
    [SerializeField] private float m_minAngleZ = -30;
    [SerializeField] private float m_maxAngleZ = 30;
    [SerializeField] private float m_speed;

    private void Update()
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
    }

        private float Rotate(float angleZ, float target)
        {
        return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.deltaTime);
    }
    }
