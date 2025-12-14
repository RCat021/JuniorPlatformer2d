using System;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public event Action<Vector2> NewDirection;

    [SerializeField] private Transform[] _pointTransforms;
    [SerializeField] private float _minSqrDistance = 0.1f;

    private Vector2[] _points;
    private int _currentIndex;

    private void Awake()
    {
        _points = new Vector2[_pointTransforms.Length];
        for (int i = 0; i < _pointTransforms.Length; i++)
        {
            _points[i] = _pointTransforms[i].position;
        }
    }

    public Vector2 GetTarget()
    {
        if (IsReachedCurrentPoint())
        {
            MoveToNextPoint();
        }

        return _points[_currentIndex];
    }

    private bool IsReachedCurrentPoint()
    {
        return ((Vector2)transform.position - _points[_currentIndex]).sqrMagnitude <= _minSqrDistance;
    }

    private void MoveToNextPoint()
    {
        int previousIndex = _currentIndex;
        var newCurrentIndex = (_currentIndex + 1) % _points.Length;
        _currentIndex = newCurrentIndex;
        NewDirection?.Invoke(_points[newCurrentIndex]);
    }
}