using UnityEngine;

public class PlayerJump : BaseMovement
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private LayerMask _groundLayer;

    public void Jump()
    {
        if (IsGrounded())
        {
            Vector2 jumpVelocity = Rigidbody.velocity;
            jumpVelocity.y = _jumpForce;
            Rigidbody.velocity = jumpVelocity;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, _checkRadius, _groundLayer);
    }
}
