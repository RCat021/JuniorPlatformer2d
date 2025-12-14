using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        Vector2 jumpVelocity = _rigidbody.velocity;
        jumpVelocity.y = _jumpForce;
        _rigidbody.velocity = jumpVelocity;
    }
}
