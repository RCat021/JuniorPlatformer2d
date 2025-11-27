using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsGround : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.1f;
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, _checkRadius, _groundLayer);
    }
}
