using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoverNotRigidbody))]
[RequireComponent(typeof(RotationMover))]
[RequireComponent(typeof(Turn))]
public class Enemy : MonoBehaviour
{

    private MoverNotRigidbody _mover;
    private RotationMover _rotationMover;
    private Turn _turn;


    private void Awake()
    {
        _mover = GetComponent<MoverNotRigidbody>();
        _rotationMover = GetComponent<RotationMover>();
        _turn = GetComponent<Turn>();
    }

    private void Update()
    {
        _mover.Move(_turn.GetTarget());
    }

    private void OnEnable()
    {
        _turn.ComeToTarget += OnRotate;
    }

    private void OnDisable()
    {
        _turn.ComeToTarget -= OnRotate;
    }

    private void OnRotate(Turn.RotationType rotationType) 
    {
        switch (rotationType)
        {
            case Turn.RotationType.ToDefault:
                _rotationMover.RotateToDefault();
                break;

            case Turn.RotationType.ToAngleY:
                _rotationMover.RotateToAngleY();
                break;
        }
    }
}
