using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    public event Action<Money, Transform> OnDie;

    public void Destroy() 
    {
        OnDie?.Invoke(this, transform);
    }
}
