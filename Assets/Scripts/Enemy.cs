using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 2f;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _currentTarget;

    private float _minSqrDistance;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startPoint = transform.position;
        _endPoint = _target.position;
        _currentTarget = _endPoint;
    }

    private void Update()
    {
        if (transform.position.IsEnoughClose(_startPoint, _minSqrDistance))
        {
            _currentTarget = _endPoint;
            _spriteRenderer.flipX = false;
        }
        else if (transform.position.IsEnoughClose(_endPoint, _minSqrDistance))
        {
            _currentTarget = _startPoint;
            _spriteRenderer.flipX = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);

    }
}
