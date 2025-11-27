using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    public event Action OnDie;

    public void Desroy() 
    {
        OnDie?.Invoke();
    }
}
