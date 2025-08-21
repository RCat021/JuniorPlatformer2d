using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.AddMoney(1);
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
