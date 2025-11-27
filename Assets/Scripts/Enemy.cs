using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Transform _target;

    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _currentTarget;

    private float _minSqrDistance;

    private void Awake()
    {
        _startPoint = transform.position;
        _endPoint = _target.position;
        _currentTarget = _endPoint;
    }

    private void Update()
    {
        if (transform.position.IsEnoughClose(_startPoint, _minSqrDistance))
        {
            _currentTarget = _endPoint;
            _mover.RotateToDefault();
        }
        else if (transform.position.IsEnoughClose(_endPoint, _minSqrDistance))
        {
            _currentTarget = _startPoint;
            _mover.RotateToAngleY(); ;
        }

        _mover.Move(_currentTarget);
    }
}
