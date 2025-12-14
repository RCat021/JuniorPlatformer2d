using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _castDistance = 0.1f;
    [SerializeField] private float _checkInterval = 0.1f;

    private bool _isGrounded;

    private Coroutine _checkRoutine;
    private bool _isChecking;

    private void OnDisable()
    {
        StopChecking();
    }

    public bool RequestGrounded()
    {
        if (!_isChecking)
        {
            _checkRoutine = StartCoroutine(GroundCheckRoutine());
            _isChecking = true;
        }

        return _isGrounded;
    }

    private void UpdateGroundedState()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            _groundCheck.position,
            _checkRadius,
            Vector2.down,
            _castDistance,
            _groundLayer
        );

        _isGrounded = hit.collider != null;
    }

    private void StopChecking()
    {
        if (_checkRoutine != null)
        {
            StopCoroutine(_checkRoutine);
            _checkRoutine = null;
            _isChecking = false;
        }
    }

    private IEnumerator GroundCheckRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_checkInterval);

        while (true)
        {
            UpdateGroundedState();
            yield return wait;
        }
    }
}