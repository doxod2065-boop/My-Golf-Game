using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public event Action<Club> Hit;
    public event Action<Club> Missed;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent <Club>())
        {
            Hit?.Invoke(this);        
        }
        else
        {
            Missed?.Invoke(this);
        }
    }
}
