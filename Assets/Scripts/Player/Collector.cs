using UnityEngine;

public class Collector : MonoBehaviour
{
    public event System.Action AddMoney;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            AddMoney?.Invoke();
            money.Destroy();
        }
    }
}