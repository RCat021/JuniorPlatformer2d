using System;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public event Action<RotationType> ComeToTarget;

    [SerializeField] private Transform _target;
    [SerializeField] private float _minSqrDistance = 0.1f;

    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _currentTarget;


    private void Awake()
    {
        _startPoint = transform.position;
        _endPoint = _target.position;
        _currentTarget = _endPoint;
    }

    public Vector3 GetTarget()
    {
        if (transform.position.IsEnoughClose(_startPoint, _minSqrDistance))
        {
            _currentTarget = _endPoint;
            ComeToTarget?.Invoke(RotationType.ToDefault);
        }
        else if (transform.position.IsEnoughClose(_endPoint, _minSqrDistance))
        {
            _currentTarget = _startPoint;
            ComeToTarget?.Invoke(RotationType.ToAngleY);
        }

        return _currentTarget;
    }

    public enum RotationType
    {
        ToDefault,
        ToAngleY
    }
}
