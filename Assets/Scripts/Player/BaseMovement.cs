using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    protected Rigidbody2D Rigidbody;

    public void SetRigidbody(Rigidbody2D rigidbody)
    {
        Rigidbody = rigidbody;
    }
}
