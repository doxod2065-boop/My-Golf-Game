using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public event Action<Stone> Hit;
    public event Action<Stone> Missed;

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
}
