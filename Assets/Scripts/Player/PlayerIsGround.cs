using UnityEngine;

public class PlayerIsGround : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _castDistance = 0.1f; 

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            _groundCheck.position,        
            _checkRadius,                  
            Vector2.down,
            _castDistance,                
            _groundLayer                  
        );

        return hit.collider != null;
    }
}
