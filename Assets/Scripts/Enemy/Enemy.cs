using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoverNotPhysical))]
[RequireComponent(typeof(MoverRotation))]
[RequireComponent(typeof(Patrol))]
public class Enemy : MonoBehaviour
{
    private Patrol _direction;
    private MoverNotPhysical _mover;
    private MoverRotation _rotationMover;
    private Patrol _turn;


    private void Awake()
    {
        _mover = GetComponent<MoverNotPhysical>();
        _rotationMover = GetComponent<MoverRotation>();
        _turn = GetComponent<Patrol>();
    }

    private void Update()
    {
        _mover.Move(_turn.GetTarget());    
    }

    private void OnEnable()
    {
        _turn.NewDirection += FlipByDirection;
    }

    private void OnDisable()
    {
        _turn.NewDirection -= FlipByDirection;
    }

    private void FlipByDirection(Vector2 targetPoint) 
    {
        _rotationMover.FlipByDirection(targetPoint);
    }
}
